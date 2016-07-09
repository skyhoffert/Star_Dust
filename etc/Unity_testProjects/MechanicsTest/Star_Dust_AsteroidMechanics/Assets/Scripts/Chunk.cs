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
            asteroidDirs[i] = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
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
            GameObject asteroid1 = (GameObject)Instantiate(Resources.Load("PreFabs/Asteroid_Test"));
            asteroid1.SendMessage("SetPosition", new Vector3(transform.position.x - .5f, 0, transform.position.z - .5f));
            asteroid1.SendMessage("SetVelocity", asteroidDirs[0]);
            GameObject asteroid2 = (GameObject)Instantiate(Resources.Load("PreFabs/Asteroid_Test"));
            asteroid2.SendMessage("SetPosition", new Vector3(transform.position.x - .5f, 0, transform.position.z + .5f));
            asteroid2.SendMessage("SetVelocity", asteroidDirs[1]);
            GameObject asteroid3 = (GameObject)Instantiate(Resources.Load("PreFabs/Asteroid_Test"));
            asteroid3.SendMessage("SetPosition", new Vector3(transform.position.x + .5f, 0, transform.position.z - .5f));
            asteroid3.SendMessage("SetVelocity", asteroidDirs[2]);
            GameObject asteroid4 = (GameObject)Instantiate(Resources.Load("PreFabs/Asteroid_Test"));
            asteroid4.SendMessage("SetPosition", new Vector3(transform.position.x + .5f, 0, transform.position.z + .5f));
            asteroid4.SendMessage("SetVelocity", asteroidDirs[2]);
        }
    }
}
