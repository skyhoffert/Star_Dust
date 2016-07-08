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
            asteroidDirs[i] = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        }
    }

    // Update is called once per frame
    void Update () {
        Act();
	}

    protected override void Act() {
        base.Act();
        if (!isAlive)
        {
	    // destroy the object
	    // only actually happens at the end of the update loop
            Destroy(gameObject);
            // make asteroids
            // change this to use a prefab, not sure correct
            Object ASTEROID_PREFAB = Resources.load("pathtoprefab");
	    GameObject newAsteroid = Instantiate(ASTEROID_PREFAB) as GameObject;
	    newAsteroid.SetTransform(TRANSFORM, VELOCITY);
        }
    }
}
