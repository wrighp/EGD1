using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeLerper : MonoBehaviour {

	public float scaleAmount = .5f;
	public float lerpTime = .15f;

	float timer;
	Vector3 start;
	Vector3 goal;
	// Use this for initialization
	void Start () {
		start = transform.localScale;
		goal = start * scaleAmount;
		timer = lerpTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0){
			transform.localScale = Vector3.Slerp(goal,start,timer/lerpTime);
		}
		else if(timer > -lerpTime){
			transform.localScale = Vector3.Slerp(goal,start,-timer/lerpTime);
		}
		else{
			transform.localScale = start;
			Destroy(this);
		}

		timer -= Time.deltaTime;
	}
}
