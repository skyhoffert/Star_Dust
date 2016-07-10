using UnityEngine;
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

	// Use this for initialization
	void Start () {
		Initialize();
	}

	protected override void Initialize() {
		base.Initialize();
		healthBase = 300;
		healthCurrent = healthBase;
		timeLastLookedForDebris = Time.time;
		timeBetwenLookingForDebris = 1;
		standardAccel = 1000;
		maxSpeed = 1;
		distanceToTarget = 1;
		amountHarvested = 0;
		holdingTankSize = 10;
		rotationSpeed = 90;
		target = GameObject.FindGameObjectWithTag("Debris");
	}

	// Update is called once per frame
	void Update () {
		Act();
	}

	protected override void Act() {
		base.Act();

		if (isAlive) {
			// only every so often, decide where to go
			if (Time.time - timeLastLookedForDebris > timeBetwenLookingForDebris) {
				timeLastLookedForDebris = Time.time;
				GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");
				// for now just look at one
				for (int i = 0; i < debris.Length; i++) {
					target = debris[i];
				}
			}
			if (target) {
				PointTowards(target.transform.position);
				if (Vector3.Distance(transform.position, target.transform.position) > distanceToTarget) {
					// move towards it
					Vector3 direction = new Vector3(transform.forward.x, 0f, transform.forward.z);
					direction = direction.normalized;
					direction *= standardAccel * Time.deltaTime;
					rigidBody.AddForce(direction);
					if (rigidBody.velocity.magnitude > maxSpeed) {
						rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
					}
				} else {
					amountHarvested += target.GetComponent<Debris>().getHarvestValue();
					Destroy(target);
					Debug.Log("current harvester amount: " + amountHarvested);
				}
			}
		}
	}

	// getters
	public float getAmountHarvested() { return amountHarvested; }
	public float getHoldingTankSize() { return holdingTankSize; }

}
