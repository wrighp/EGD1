using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
/// <summary>
/// Makes camera view extend vertically instead of horizontally when aspect ratio is changed
/// </summary>
public class AspectFit : MonoBehaviour {

	Camera cam;
	public float baseSize = 7.7f;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		cam.orthographicSize = baseSize / cam.aspect;
	}
}
