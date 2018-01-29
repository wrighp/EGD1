using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour {

    public float currentscroll = 0.0f;
    public float speed = 0.01f;
    private Material _material;

    void Start(){
        _material = GetComponent<Renderer>().material;
    }

    void Update(){
        currentscroll += speed * Time.deltaTime;
        currentscroll = currentscroll % 1;
        _material.mainTextureOffset = new Vector2(-currentscroll, 0);
    }
}
