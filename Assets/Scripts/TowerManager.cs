using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public GameObject[] buildingTypes;

    [HideInInspector]
    public static TowerManager i = null;
    [HideInInspector]
    public List<Building> activeBuildings = new List<Building>();
    public float waterLevelSpeed = .15f;

    private float researchLevel = 0f;
    private int plasticAmount = 10;
    private int metalAmount = 10;
    private int population = 10;

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
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            AddTower(1);
        }
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
