using UnityEngine;
using System.Collections;

public class Asteroid : Entity {

    protected float health;

	// Use this for initialization
	void Start ()
    {
        isAlive = true;
        velocity = new Vector3(0, 0, 0);
        health = 100;
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ApplyDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
