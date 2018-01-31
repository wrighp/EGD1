using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {

    bool loading = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && !loading){
            object[] tmp = { 1, "TowerTest" };
            GetComponent<FadeSystem>().StartCoroutine("PerformFade", tmp);
            loading = true;
        }
	}
}
