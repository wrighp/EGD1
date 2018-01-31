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

    [HideInInspector]
    public float emissionLevel = 0f;
    [HideInInspector]
    public float researchLevel = 0f;
   

	int plasticAmount = 14;
	public int PlasticAmount {
		get {
			return plasticAmount;
		}
		set {
			if(plasticAmount != value && itemCounters[1].gameObject.GetComponent<SizeLerper>() == null){
				itemCounters[1].gameObject.AddComponent<SizeLerper>().scaleAmount = plasticAmount < value ? 1.5f : .5f;
			}
			plasticAmount = value;

		}
	}
	int metalAmount = 14;

	public int MetalAmount {
		get {
			return metalAmount;
		}
		set {
			if(metalAmount != value && itemCounters[2].gameObject.GetComponent<SizeLerper>() == null){
				itemCounters[2].gameObject.AddComponent<SizeLerper>().scaleAmount = metalAmount < value ? 1.5f : .5f;
			}
			metalAmount = value;
		}
	}
   
	int greenhouseAmount = 10;

	public int GreenhouseAmount {
		get {
			return greenhouseAmount;
		}
		set {
			if(greenhouseAmount != value && itemCounters[3].gameObject.GetComponent<SizeLerper>() == null){
				itemCounters[3].gameObject.AddComponent<SizeLerper>().scaleAmount = greenhouseAmount < value ? 1.5f : .5f;
			}
			greenhouseAmount = value;
		}
	}

	int population = 10;

	public int Population {
		get {
			return population;
		}
		set {
			if(population != value &&	itemCounters[0].gameObject.GetComponent<SizeLerper>() == null){
				itemCounters[0].gameObject.AddComponent<SizeLerper>().scaleAmount = population < value ? 1.5f : .5f;
			}
			population = value;
		}
	}

    private Slider researchSlider;

	// Use this for initialization
	void Start () {
        if (i == null) {
            i = this;
        } else {
            Destroy(this);
        }

        object[] tmp = { -1, "TowerTest" };
        GetComponent<FadeSystem>().StartCoroutine("PerformFade", tmp);

        researchSlider = GameObject.FindObjectOfType<Slider>();
        researchSlider.value = 0;

		AddTower(0);
		AddTower(0);

	}
	
	// Update is called once per frame
	void Update () {
        itemCounters[0].text = population.ToString();
        itemCounters[1].text = plasticAmount.ToString();
        itemCounters[2].text = metalAmount.ToString();
        itemCounters[3].text = greenhouseAmount.ToString();
        researchSlider.value = researchLevel;
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

		string[] sounds = { "fall1","fall2" };
		//string[] sounds = { "dirt2", "dirt4","fall1","fall2" };
		SoundManager.GetSound(sounds.Pick(),pitchShiftRange: .1f).Play();
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
