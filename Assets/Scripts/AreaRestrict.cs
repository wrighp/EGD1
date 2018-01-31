using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Restricts gameobject to certain zone
/// </summary>
public class AreaRestrict : MonoBehaviour {
	
	public TowerManager towerManager;
	public float minHeight;
	public float extraHeight = 1f;

	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}

	void Update(){
		//Move camera against water to make it look like it is rising
		cam.transform.position += new Vector3(0,Time.deltaTime * -towerManager.GetWaterSpeed(),0);
	}

	// Update is called once per frame
	void LateUpdate () {
		Transform camTransform = cam.transform;
		float camY = camTransform.position.y;
		float viewDown = camY - cam.orthographicSize;

		//Clamps camera between it's upper and lower bounds defined by minHeight and extraHeight after tower

		if(viewDown <= minHeight){
			cam.transform.position = new Vector3(0,camY - viewDown + minHeight,cam.transform.position.z);
		}
		else{
			var building = towerManager.GetHighestBuilding();
			float towHeight = extraHeight;
			if(building != null){
				towHeight += building.transform.position.y;
			}

			if(camY > towHeight){
				cam.transform.position = new Vector3(0,Mathf.Max(towHeight,camY - viewDown + minHeight),cam.transform.position.z);
			}

		}
	}

	void OnDrawGizmosSelected()
	{
		if(cam == null){
			return;
		}
		Gizmos.color = Color.red;
		Vector3 vec = Vector3.up * minHeight;
		Gizmos.DrawLine(vec + Vector3.left * 20f, vec + Vector3.right * 20f);

		var building = towerManager.GetHighestBuilding();
		float towHeight = extraHeight + cam.orthographicSize;
		if(building != null){
			towHeight += building.transform.position.y;
		}
		Vector3 vec2 = Vector3.up * towHeight;
		Gizmos.DrawLine(vec2 + Vector3.left * 20f, vec2 + Vector3.right * 20f);
	}

}
