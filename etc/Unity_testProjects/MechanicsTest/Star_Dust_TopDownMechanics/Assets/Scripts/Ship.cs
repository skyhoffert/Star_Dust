using UnityEngine;
using System.Collections;

public class Ship : Entity {

    // ship stats
    public float health = 500;
    protected bool hasCollided = false;
    // where the ship should point
    protected Quaternion targetRotation;

    // the speed that the player can rotation in degrees / second
    public float rotationSpeed = 360;
    // other speeds
    public float standardAccel = 5f;
    public float maxSpeed = 8;

    // Use this for initialization
    void Start ()
    {
        standardAccel = 5f;
        maxSpeed = 10;
        health = 500;
        isAlive = true;
        hasCollided = false;
        rotationSpeed = 360;
        isAlive = true;
        velocity = new Vector3(0, 0, 0);
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    // TODO
    // pretty self explanatory
    private void PointTowardsPlayer()
    {

    }

    public void ApplyDamage(float amount)
    {
        health -= amount;
        Debug.Log("damage taken: " + amount + ", current health: " + health);
    }
}
