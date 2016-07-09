using UnityEngine;
using System.Collections;

public class Asteroid : Entity {

    private Vector3 targetPosition, targetVelocity;
    private bool velSet = false, posSet = false;

	// Use this for initialization
	void Start () {
        Initialize();
    }

    public void SetPosition(Vector3 targPos) {
        targetPosition = targPos;
        posSet = true;
    }

    public void SetVelocity(Vector3 targVel) {
        targetVelocity = targVel;
        velSet = true;
    }

    protected override void Initialize() {
        base.Initialize();
        healthBase = 100;
        healthCurrent = healthBase;
        if (velSet) {
            velocity = targetVelocity;
        }
        if (posSet) {
            transform.position = targetPosition;
        }
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
