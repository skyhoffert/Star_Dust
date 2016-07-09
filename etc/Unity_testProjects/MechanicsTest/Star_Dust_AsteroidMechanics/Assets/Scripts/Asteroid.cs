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

    public void SetPosition(Vector3 targetPosition) {
        transform.position = targetPosition;
    }

    public void SetVelocity(Vector3 targetVelocity) {
        velocity = targetVelocity;
        Debug.Log("velX: " +velocity.x + "velZ: " + velocity.z);
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
