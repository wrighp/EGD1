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
    public float waterLevelBaseSpeed = .15f;
	public float towerHeight = 3f;
    public Text[] itemCounters;

    private float researchLevel = 0f;
    [HideInInspector]
    public int plasticAmount = 10;
    [HideInInspector]
    public int metalAmount = 10;
    [HideInInspector]
    public int greenhouseAmount = 10;
    [HideInInspector]
    public int population = 10;

	// Use this for initialization
	void Start () {
        if (i == null) {
            i = this;
        } else {
            Destroy(this);
        }

		AddTower(0);
		AddTower(0);
	}
	
	// Update is called once per frame
	void Update () {
        itemCounters[0].text = population.ToString();
        itemCounters[1].text = plasticAmount.ToString();
        itemCounters[2].text = metalAmount.ToString();
        itemCounters[2].text = greenhouseAmount.ToString();

    }

    public void AddTower(int i) {
        Vector3 pos;    
        if (activeBuildings.Count == 0) {
            pos = new Vector3(0, transform.position.y, 0);
        } else {
            pos = new Vector3(0, activeBuildings[activeBuildings.Count - 1].transform.position.y + towerHeight, 0);
        }
        GameObject go = Instantiate(buildingTypes[i], pos, Quaternion.identity);
        activeBuildings.Add(go.GetComponent<Building>());

    }

	public Building GetHighestBuilding(){
		if(activeBuildings.Count == 0){
			return null;
		}
		return activeBuildings[activeBuildings.Count - 1];
	}

	//Water speed after changes
	public float GetWaterSpeed(){
		return waterLevelBaseSpeed;
	}

}
