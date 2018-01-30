using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
/// <summary>
/// Makes camera view extend vertically instead of horizontally when aspect ratio is changed
/// </summary>
public class AspectFit : MonoBehaviour {

	Camera camera;
	public float baseSize = 7.7f;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		camera.orthographicSize = baseSize / camera.aspect;
	}
}
