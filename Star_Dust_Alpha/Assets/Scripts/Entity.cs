using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour {
	// controller for movement/collision
	protected Rigidbody rigidBody;
	// if the velocity/position needs to be set
	private Vector3 targetPosition, targetVelocity;
	private bool velSet = false, posSet = false;

	// stats
	protected bool isAlive;
	protected float healthBase, healthCurrent;

	public static float COLLISION_DAMAGE_MODIFIER = .5f;

	// Use this for initialization
	void Start() {
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

	// the standard method to initialize the variables in this class
	// not using Start() because it cannot be called by sub classes
	protected virtual void Initialize() {
		isAlive = true;
		healthBase = 1;
		healthCurrent = 1;
		rigidBody = GetComponent<Rigidbody>();
		// if the velocity/position are set initially
		if (velSet) {
			rigidBody.velocity = targetVelocity;
		}
		if (posSet) {
			transform.position = targetPosition;
		}
	}

	// Update is called once per frame
	void FixedUpdate() {
		Act();
	}

	// standard actions for every entity
	// Act() is the key method for entities
	protected virtual void Act() {
		// if the entity should be doing stuff
		if (isAlive) {
			// do nothing?
			// rigid body is great
			transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		}
	}

	public virtual void ApplyDamage(float amount) {
		healthCurrent -= amount;
		if (healthCurrent <= 0) {
			healthCurrent = 0;
			isAlive = false;
		}
		// debugging
		// Debug.Log("Damage Applied: " +amount + ", My max health: " + healthBase + ", My current health: " + healthCurrent);
	}

	public virtual void CollisionWithEntity(float collidingMass, float collidingVelocity) {
		float damage = collidingMass * collidingVelocity * COLLISION_DAMAGE_MODIFIER;
		// taking this away for debugging
		// ApplyDamage(damage);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider) {
			if (collision.collider.GetComponent<Entity>()) {
				collision.collider.GetComponent<Entity>().CollisionWithEntity(rigidBody.mass, collision.relativeVelocity.magnitude);
				CollisionWithEntity(collision.collider.GetComponent<Entity>().rigidBody.mass, collision.relativeVelocity.magnitude);
			}
		}
	}

	public float getHealthCurrent() { return healthCurrent; }
	public float getHealthBase() { return healthBase; }

}