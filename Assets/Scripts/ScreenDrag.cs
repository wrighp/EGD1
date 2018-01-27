using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDrag : MonoBehaviour {

	public Transform moveTarget;
	public Vector3 scrollSpeed = Vector3.up; //Negative for moving other direction

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){	}

	public void Scroll(){
		print(gameObject.name);
		moveTarget.transform.position += Time.deltaTime * scrollSpeed;
	}
}
