using UnityEngine;
using System.Collections;

// we don't need to waste resources with a rigid body, we can emulate that behavior
// with more primitive elements
public class Debris : Entity {
	// default size for debris shard
	public static float DEFAULT_SIZE = .1f;

	private float harvestValue;

	// Use this for initialization
	void Start () {
		Initialize();
	}

	protected override void Initialize() {
		base.Initialize();
		healthBase = 100;
		healthCurrent = healthBase;
		harvestValue = 1;
	}

	// Update is called once per frame
	void Update () {
		Act();
	}

	protected override void Act() {
		base.Act();
		if (!isAlive) {
			Destroy(gameObject);
		}
	}

	public float getHarvestValue() { return harvestValue; }
}
