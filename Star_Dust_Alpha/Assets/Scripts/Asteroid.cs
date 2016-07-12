using UnityEngine;
using System.Collections;

public class Asteroid : Entity {

	// default size for the asteroid
	public static float DEFAULT_SIZE = .3f;

	private int numDebris;

    protected override void Initialize() {
        base.Initialize();
        healthBase = 100;
        healthCurrent = healthBase;
		numDebris = 3;
    }

    protected override void Act() {
        base.Act();
        if (!isAlive) {
            Destroy(gameObject);
			// make debris
			GameObject[] newDebris = new GameObject[numDebris];
			for (int i = 0; i < numDebris; i++) {
				newDebris[i] = (GameObject)Instantiate(Resources.Load("PreFabs/Debris_Shard"));
				float locX = transform.position.x + Random.Range(-.5f, .5f);
				float locZ = transform.position.z + Random.Range(-.5f, .5f);
				float iter = 0;
				while (Physics.CheckSphere(new Vector3(locX, 0, locZ), Debris.DEFAULT_SIZE)) {
					locX = transform.position.x + Random.Range((float)(-.5 - iter), (float)(.5 + iter));
					locZ = transform.position.z + Random.Range((float)(-.5 - iter), (float)(.5 + iter));
					iter += .2f;
				}
				newDebris[i].SendMessage("SetPosition", new Vector3(locX, 0, locZ));
				newDebris[i].SendMessage("SetVelocity", new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
				newDebris[i].transform.parent = GameObject.FindGameObjectWithTag("DebrisParent").transform;
			}
		}
    }

}
