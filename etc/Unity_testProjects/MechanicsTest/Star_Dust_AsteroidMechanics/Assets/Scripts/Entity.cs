using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Entity : MonoBehaviour {

    // controller for movement
    protected CharacterController controller;

    // movement
    protected Vector3 velocity;

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
        velocity = new Vector3(0, 0, 0);
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        Act();
	}

    // standard actions for every entity
    // Act() is the key method for entities
    protected virtual void Act()
    {
        // if the entity should be doing stuff
        if (isAlive) {
            MoveByVel();
        }
    }

    // move this controller by the velocity
    protected virtual void MoveByVel() {
        controller.Move(velocity * Time.deltaTime);
    }

    public virtual void ApplyDamage(float amount) {
        healthCurrent -= amount;
        if (healthCurrent <= 0){
            healthCurrent = 0;
            isAlive = false;
        }
    }
}
