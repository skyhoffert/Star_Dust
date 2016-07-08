using UnityEngine;
using System.Collections;

public class Asteroid : Entity {

    public Asteroid(Transform desiredTransform, Vector3 desiredVelocity) {
        transform.position = desiredTransform.position;
        velocity = desiredVelocity;
    }

	// Use this for initialization
	void Start () {
        Initialize();
    }

    protected override void Initialize() {
        base.Initialize();
        healthBase = 100;
        healthCurrent = healthBase;
    }

    // Update is called once per frame
    void Update () {
        Act();
	}

    protected override void Act() {
        base.Act();
        if (!isAlive) {
            Destroy(gameObject);
            // make debris
        }
    }

}
