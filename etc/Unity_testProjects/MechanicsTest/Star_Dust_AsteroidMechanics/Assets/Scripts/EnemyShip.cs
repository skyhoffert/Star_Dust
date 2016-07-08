using UnityEngine;
using System.Collections;

public class EnemyShip : Ship {

	// Use this for initialization
	void Start ()
    {
        Initialize();
    }

    protected override void Initialize() {
        base.Initialize();
        healthBase = 500;
        healthCurrent = healthBase;
    }

    // Update is called once per frame
    void Update () {
        Act();
        if (!isAlive)
        {
            Destroy(gameObject);
        }
	}
}
