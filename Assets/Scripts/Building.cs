using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public int plasticCost = 0;
    public int metalCost = 0;
    public int peopleCost = 0;
    public int greenhouseCost = 0;
    //While active number of population that is added to the tower
    public int peopleBonus = 0;
    public float researchValue = .01f;
    public float carbonEmission = .01f;

    public float resourceGenerationTime = 0;

    public GameObject dropResource = null;

    private float chargeTime = 0f;
    private bool isDestroyed = false;

    // Use this for initialization
    void Start () {
        TowerManager.i.plasticAmount -= plasticCost;
        TowerManager.i.metalAmount -= plasticCost;
        TowerManager.i.population += peopleBonus;
        TowerManager.i.greenhouseAmount -= greenhouseCost;
        TowerManager.i.emissionLevel += carbonEmission;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.down * Time.deltaTime * (TowerManager.i.GetWaterSpeed() * Mathf.Clamp01(1-TowerManager.i.researchLevel)));
        TowerManager.i.researchLevel += researchValue * Time.deltaTime; 

        if (isDestroyed) return;

        chargeTime += Time.deltaTime;
        if (chargeTime >= resourceGenerationTime ) {
            chargeTime = 0;
            if (dropResource != null) {
                Instantiate(dropResource, transform.position, Quaternion.identity);
            }
        }

        if (transform.position.y <= TowerManager.i.transform.position.y) {
            DisableBuilding();
        }
    }

    public void DisableBuilding() {
        isDestroyed = true;
        GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
        TowerManager.i.activeBuildings.Remove(this);
        TowerManager.i.emissionLevel -= carbonEmission;

    }
}
