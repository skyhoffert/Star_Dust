using UnityEngine;
using System.Collections;

public class EnemyShip : Ship {

	// 
	GameObject player;

    protected override void Initialize() {
        base.Initialize();
        healthBase = 500;
        healthCurrent = healthBase;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	protected override void Act() {
		base.Act();
		if (isAlive) {
			if (player) {
				PointTowards(player.transform.position);
			}
		} else {
			Destroy(gameObject);
		}
	}
}
