using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationRestriction : MonoBehaviour {

    public int plasticAmount = 0;
    public int metalAmount = 0;
    public int greenhouseAmount = 0;
    public int peopleAmount = 0;

    private Button button;

    void Start() {
        button = GetComponent<Button>();
    }

	// Update is called once per frame
	void Update () {
        button.interactable = plasticAmount <= TowerManager.i.PlasticAmount &&
                              metalAmount <= TowerManager.i.MetalAmount &&
                              greenhouseAmount <= TowerManager.i.GreenhouseAmount &&
                              peopleAmount <= TowerManager.i.Population;
    }
}
