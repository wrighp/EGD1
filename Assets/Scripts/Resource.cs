using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

    public int plasticValue;
    public int metalValue;

    private float travelTimeCurrent = 0;
    private float travelTimeMax = 3;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 controlPoint1;
    // Use this for initialization
    void Start () {
        startPoint = this.transform.position;
        Vector3 tmp = TowerManager.i.itemCounters[0].rectTransform.position;
        endPoint = Camera.main.ScreenToWorldPoint(new Vector3(tmp.x, tmp.y, 0));
        controlPoint1 = new Vector3(endPoint.x, startPoint.y, 0);
        print("["+startPoint+"], "+ "[" + controlPoint1 + "], " + "[" + endPoint + "]" );

    }
	
	// Update is called once per frame
	void Update () {
        travelTimeCurrent = Mathf.Clamp(travelTimeCurrent + Time.deltaTime,0,travelTimeMax);
        transform.position = CubeBezier3(startPoint, controlPoint1, endPoint, endPoint, travelTimeCurrent/travelTimeMax);
        if (travelTimeCurrent >= travelTimeMax){
            TowerManager.i.plasticAmount += plasticValue;
            TowerManager.i.metalAmount += metalValue;
            Destroy(this.gameObject);
        }
	}

    public static Vector3 CubeBezier3(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, float time)
    {
        return (((-start + 3 * (control1 - control2) + end) * time + (3 * (start + control2) - 6 * control1)) * time + 3 * (control1 - start)) * time + start;
    }
}
