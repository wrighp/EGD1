using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

    public int plasticValue;
    public int metalValue;
    public int greenhouseValue;

    private float travelTimeCurrent = 0;
    private float travelTimeMax = 3;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 controlPoint1;

    void Start () {
        startPoint = this.transform.position;
        Vector3 tmp = TowerManager.i.itemCounters[0].rectTransform.position;
        endPoint = Camera.main.ScreenToWorldPoint(new Vector3(tmp.x, tmp.y, 0));
        controlPoint1 = new Vector3(endPoint.x, startPoint.y, 0);

		var startSound = SoundManager.GetSound("run_rock_3",pitchShiftRange: .1f);
		startSound.volume = .5f;
		startSound.Play();
    }
	
	// Update is called once per frame
	void Update () {
        travelTimeCurrent = Mathf.Clamp(travelTimeCurrent + Time.deltaTime,0,travelTimeMax);
        transform.position = CubeBezier3(startPoint, controlPoint1, endPoint, endPoint, travelTimeCurrent/travelTimeMax);
        if (travelTimeCurrent >= travelTimeMax){
			TowerManager.i.PlasticAmount += plasticValue;
			TowerManager.i.MetalAmount += metalValue;
            TowerManager.i.GreenhouseAmount += greenhouseValue;

			ResourceNoise();

            Destroy(this.gameObject);
        }
	}

	void ResourceNoise(){
		if(plasticValue > 0){
			SoundManager.GetSound("run_glass_3",pitchShiftRange: .1f).Play();
		}
		if(metalValue > 0){
			SoundManager.GetSound("ladder2",pitchShiftRange: .1f).Play();
		}
		if(greenhouseValue > 0){
			string[] dirtSounds = { "dirt2","dirt4" };
			SoundManager.GetSound(dirtSounds.Pick(),pitchShiftRange: .1f).Play();
		}
	}

    public static Vector3 CubeBezier3(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, float time)
    {
        return (((-start + 3 * (control1 - control2) + end) * time + (3 * (start + control2) - 6 * control1)) * time + 3 * (control1 - start)) * time + start;
    }
}
