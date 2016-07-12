using UnityEngine;
using System.Collections;

public class StarShip : Entity {

	// private Shop theShop;
	private float amountOfResources;

	protected override void Initialize() {
		base.Initialize();
		healthBase = 10000;
		healthCurrent = healthBase;
		amountOfResources = 100;
	}

	protected override void Act() {
		base.Act();
	}

	public bool BuildNewPlayer(float cost, float deathTimer) {
		if (amountOfResources > cost) {
			return false;
		}
		amountOfResources -= cost;
		StartCoroutine("BuildPlayer", deathTimer);
		return true;
	}

	IEnumerator BuildPlayer(float deathTimer) {
		yield return new WaitForSeconds(deathTimer);
		GameObject newPlayer = (GameObject)Instantiate(Resources.Load("PreFabs/Player"), transform.position + new Vector3(0, 0, 2), transform.rotation);
	}
}
