using UnityEngine;
using System.Collections;

public class EnemyShip : Ship {

	// 
	GameObject player;

	// Use this for initialization
	void Start () {
        Initialize();
    }

    protected override void Initialize() {
        base.Initialize();
        healthBase = 500;
        healthCurrent = healthBase;
		player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update () {
        Act();
	}

	protected override void Act() {
		base.Act();
		if (isAlive) {
			PointTowards(player.transform.position);
		} else {
			Destroy(gameObject);
		}
	}
}
