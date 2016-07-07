using UnityEngine;
using System.Collections;

public class EnemyShip : Ship {

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        standardAccel = 5f;
        maxSpeed = 10;
        health = 500;
        isAlive = true;
        hasCollided = false;
        rotationSpeed = 360;
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
