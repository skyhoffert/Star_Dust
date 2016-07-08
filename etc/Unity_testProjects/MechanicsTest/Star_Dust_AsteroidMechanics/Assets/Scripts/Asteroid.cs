using UnityEngine;
using System.Collections;

public class Asteroid : Entity {

	// Use this for initialization
	void Start () {
        	Initialize();
	}

	// will be called after instantiating
	public void SetTransform(Transform targetTransform, Vector3 targetVelocity){
		transform.position = targetTransform.position;
		velocity = targetVelocity;
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
