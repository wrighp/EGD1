using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour {

    public GameObject[] buildingTypes;

    [HideInInspector]
    public static TowerManager i = null;
    [HideInInspector]
    public List<Building> activeBuildings = new List<Building>();
    public float waterLevelSpeed = .15f;
    public Text[] itemCounters;

    private float researchLevel = 0f;
    [HideInInspector]
    public int plasticAmount = 10;
    [HideInInspector]
    public int metalAmount = 10;
    [HideInInspector]
    public int population = 10;

	// Use this for initialization
	void Start () {
        if (i == null) {
            i = this;
        } else {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
        itemCounters[0].text = "p: " + plasticAmount;
        itemCounters[1].text = "m: " + metalAmount;
        itemCounters[2].text = "h: " + population;
    }

    public void AddTower(int i) {
        Vector3 pos;    
        if (activeBuildings.Count == 0) {
            pos = new Vector3(0, transform.position.y + 1.65f, 0);
        } else {
            pos = new Vector3(0, activeBuildings[activeBuildings.Count - 1].transform.position.y + 3.25f, 0);
        }
        GameObject go = Instantiate(buildingTypes[i], pos, Quaternion.identity);
        activeBuildings.Add(go.GetComponent<Building>());

    }
}
