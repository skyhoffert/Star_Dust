using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Harvester : Ship {

	// to avoid looking for a target every frame
	private float timeLastLookedForDebris;
	private float timeBetwenLookingForDebris;
	private GameObject target;

	// don't constantly accelerate
	private float distanceToTarget;

	// Stats
	private float amountHarvested;
	private float holdingTankSize;

	// for the holding tank UI
	public Image holdingTankBar;

	protected override void Initialize() {
		base.Initialize();
		healthBase = 300;
		healthCurrent = healthBase;
		timeLastLookedForDebris = Time.time;
		timeBetwenLookingForDebris = 1;
		accelBase = 1000;
		maxspeedBase = 1;
		distanceToTarget = 1;
		amountHarvested = 0;
		holdingTankSize = 10;
		rotationSpeed = 90;
		target = GameObject.FindGameObjectWithTag("Debris");
	}

	protected override void Act() {
		base.Act();

		if (isAlive) {
			if (amountHarvested < holdingTankSize) {
				// only every so often, decide where to go
				if (Time.time - timeLastLookedForDebris > timeBetwenLookingForDebris) {
					SetTargetNearestDebris();
				}
				if (target) {
					PointTowards(target.transform.position);
					if (Vector3.Distance(transform.position, target.transform.position) > distanceToTarget) {
						// move towards it
						Vector3 direction = new Vector3(transform.forward.x, 0f, transform.forward.z);
						direction = direction.normalized;
						direction *= accelBase * Time.deltaTime;
						rigidBody.AddForce(direction);
						if (rigidBody.velocity.magnitude > maxspeedBase) {
							rigidBody.velocity = rigidBody.velocity.normalized * maxspeedBase;
						}
					} else {
						amountHarvested += target.GetComponent<Debris>().getHarvestValue();
						Destroy(target);
						holdingTankBar.fillAmount = amountHarvested / holdingTankSize;
					}
				}
			}
		} else {
			// remove the other ui elements
			Destroy(this.uiCanvas.gameObject);
			Destroy(this.healthBar.gameObject);
		}

	}

	// sets its target to the closest debris
	// returns true if it was successful
	// false if no debris exist
	private bool SetTargetNearestDebris() {
		float closestDistance = float.MaxValue;
		float dist;
		bool wasSet = false;
		timeLastLookedForDebris = Time.time;
		GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");
		// for now just look at one
		for (int i = 0; i < debris.Length; i++) {
			dist = Vector3.Distance(transform.position, debris[i].transform.position);
			if (dist < closestDistance) {
				closestDistance = dist;
				target = debris[i];
				wasSet = true;
			}
		}
		return wasSet;
	}

	// getters
	public float getAmountHarvested() { return amountHarvested; }
	public float getHoldingTankSize() { return holdingTankSize; }

}
