﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour {

    // controller for movement/collision
    protected Rigidbody rigidBody;

    // stats
    protected bool isAlive;
    protected float healthBase, healthCurrent;

    public static float COLLISION_DAMAGE_MODIFIER = .5f;

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
        // debugging
        // Debug.Log("Damage Applied: " +amount + ", My max health: " + healthBase + ", My current health: " + healthCurrent);
    }

    public virtual void CollisionWithEntity(float collidingMass, float collidingVelocity) {
        float damage = collidingMass * collidingVelocity * COLLISION_DAMAGE_MODIFIER;
        ApplyDamage(damage);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider != null) {
            if (collision.collider.GetComponent<Entity>()) {
                collision.collider.GetComponent<Entity>().CollisionWithEntity(rigidBody.mass, collision.relativeVelocity.magnitude);
                CollisionWithEntity(collision.collider.GetComponent<Entity>().rigidBody.mass, collision.relativeVelocity.magnitude);
            }
        }
    }
}