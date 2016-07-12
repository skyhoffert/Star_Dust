using UnityEngine;
using System.Collections;

public class Chunk : Entity {

    private int numAsteroids;
    private Vector3[] asteroidDirs;

    protected override void Initialize() {
        base.Initialize();
        healthBase = 100;
        healthCurrent = healthBase;
        numAsteroids = Random.Range(2,4);
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
				float locX = transform.position.x + Random.Range(-.5f, .5f);
				float locZ = transform.position.z + Random.Range(-.5f, .5f);
				float iter = 0;
				while (Physics.CheckSphere(new Vector3(locX, 0, locZ), Asteroid.DEFAULT_SIZE)) {
					locX = transform.position.x + Random.Range((float) (-.5 - iter), (float) (.5 + iter));
					locZ = transform.position.z + Random.Range((float) (-.5 - iter), (float) (.5 + iter));
					iter += .2f;
				}
				asteroids[i].SendMessage("SetPosition", new Vector3(locX, 0, locZ));
                asteroids[i].SendMessage("SetVelocity", asteroidDirs[i]);
				asteroids[i].transform.parent = gameObject.transform.parent;
            }
        }
    }
}
