using UnityEngine;
using System.Collections;

using Items;

public class StarShip : Entity {

	// private Shop theShop;
	private float amountOfResources;

	private Item[] shop;

	protected override void Initialize() {
		base.Initialize();
		healthBase = 10000;
		healthCurrent = healthBase;
		amountOfResources = 100;
		shop = new Item[Item.NUM_ITEMS];
		shop[0] = new ExtraBattery();
		shop[1] = new ArmorPiece();
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
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>().Reconstruct(transform.GetChild(0).transform.position);
	}
}
