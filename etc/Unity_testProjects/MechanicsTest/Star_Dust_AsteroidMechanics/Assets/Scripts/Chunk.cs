using UnityEngine;
using System.Collections;

public class Chunk : Entity {

    private int numAsteroids;
    private Vector3[] asteroidDirs;

	// Use this for initialization
	void Start () {
        Initialize();
    }

    protected override void Initialize() {
        base.Initialize();
        healthBase = 100;
        healthCurrent = healthBase;
        numAsteroids = 6;
        asteroidDirs = new Vector3[numAsteroids];
        GenAsteroidDirs();
    }

    // get the directions the asteroids will be spawned now
    // less calculation later
    private void GenAsteroidDirs() {
        for (int i = 0; i < numAsteroids; i++) {
            asteroidDirs[i] = new Vector3(1, 0, 1);
        }
    }

    // Update is called once per frame
    void Update () {
        Act();
	}

    protected override void Act() {
        base.Act();
        if (!isAlive) {
            // this will destroy after current loop
            // so it will be good for the remainder
            Destroy(gameObject);
            // make asteroids
            GameObject newAsteroid = (GameObject)Instantiate(Resources.Load("PreFabs/Asteroid_Test"));
            newAsteroid.SendMessage("SetPosition", new Vector3(transform.position.x, 0, transform.position.z));
            newAsteroid.SendMessage("SetVelocity", asteroidDirs[0]);
        }
    }
}
