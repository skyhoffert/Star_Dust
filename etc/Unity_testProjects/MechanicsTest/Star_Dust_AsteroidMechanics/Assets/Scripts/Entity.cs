using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour {

    // controller for movement/collision
    protected Rigidbody rigidBody;

    // stats
    protected bool isAlive;
    protected float healthBase, healthCurrent;
    protected float mass;

    // Use this for initialization
    void Start () {
        Initialize();
    }

    // the standard method to initialize the variables in this class
    // not using Start() because it cannot be called by sub classes
    protected virtual void Initialize()
    {
        isAlive = true;
        healthBase = 1;
        healthCurrent = 1;
        mass = 1;
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Act();
	}

    // standard actions for every entity
    // Act() is the key method for entities
    protected virtual void Act()
    {
        // if the entity should be doing stuff
        if (isAlive) {
            // do nothing?
            // rigid body is great
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    public virtual void ApplyDamage(float amount) {
        healthCurrent -= amount;
        if (healthCurrent <= 0){
            healthCurrent = 0;
            isAlive = false;
        }
    }
}
