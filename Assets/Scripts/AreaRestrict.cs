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

	Camera camera;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
	}

	// Update is called once per frame
	void LateUpdate () {
		Transform camTransform = camera.transform;
		float camY = camTransform.position.y;
		float viewDown = camY - camera.orthographicSize;
		float viewUp = camY + camera.orthographicSize;

		if(viewDown <= minHeight){
			camera.transform.position = new Vector3(0,camY - viewDown + minHeight,camera.transform.position.z);
		}
		else{
			/*var building = towerManager.GetHighestBuilding();
			float towHeight = minHeight;
			if(building != null){
				towHeight += building.transform.position.y;
			}

			if(viewUp > towHeight){
				camera.transform.position = new Vector3(0,camY - viewUp + towHeight,0);
			}
			*/
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Vector3 vec = Vector3.up * minHeight;
		Gizmos.DrawLine(vec + Vector3.left * 20f, vec + Vector3.right * 20f);
		//Gizmos.DrawWireCube(offset, (Vector3)area.size);
	}

}
