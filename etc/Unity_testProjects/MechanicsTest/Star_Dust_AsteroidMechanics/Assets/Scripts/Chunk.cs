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
        numAsteroids = Random.Range(3,6);
        asteroidDirs = new Vector3[numAsteroids];
        GenAsteroidDirs();
    }

    // get the directions the asteroids will be spawned now
    // less calculation later
    private void GenAsteroidDirs() {
        for (int i = 0; i < numAsteroids; i++) {
            asteroidDirs[i] = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        }
    }

    protected override void Act() {
        base.Act();
        if (!isAlive) {
            // this will destroy after current loop
            // so it will be good for the remainder
            Destroy(gameObject);
            // make asteroids
            GameObject[] asteroids = new GameObject[numAsteroids];
            for (int i = 0; i < numAsteroids; i++) {
                asteroids[i] = (GameObject)Instantiate(Resources.Load("PreFabs/Asteroid_Test"));
                asteroids[i].SendMessage("SetPosition", new Vector3(transform.position.x + Random.Range(-1, 1), 0, transform.position.z + Random.Range(-1, 1)));
                asteroids[i].SendMessage("SetVelocity", asteroidDirs[i]);
            }
        }
    }
}
