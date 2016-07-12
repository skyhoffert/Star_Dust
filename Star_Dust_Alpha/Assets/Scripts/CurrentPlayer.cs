using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour {

	// the player's ship
	public GameObject playerShip;

	private float buildCost;

	private bool isBuilding;

	// death timer
	private float deathTimer;

	// Use this for initialization
	void Start () {
		buildCost = 100;
		deathTimer = 2;
		isBuilding = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerShip) {
		} else {
			if (isBuilding) {
				playerShip = GameObject.FindGameObjectWithTag("Player");
				if (playerShip) {
					isBuilding = false;
				}
			} else {
				isBuilding = true;
				GameObject.FindGameObjectWithTag("StarShip").GetComponent<StarShip>().BuildNewPlayer(buildCost, deathTimer);
			}
		}
	}

}
