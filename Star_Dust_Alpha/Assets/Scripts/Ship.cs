using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ship : Entity {

    // rotation
    // where the ship should point
    protected Quaternion targetRotation;

    // ship stats
    protected bool hasCollided;
    // the speed that the player can rotation in degrees / second
    protected float rotationSpeed;
    // other speeds
    protected float accelBase;
    protected float maxspeedBase;

	// how much a rebuild cost is worth
	public float buildCost;

	public Canvas uiCanvas;
	public Image healthBar;

    protected override void Initialize() {
        // initialize base stuff
        base.Initialize();
		healthBase = 100;
		healthCurrent = healthBase;
        hasCollided = false;
        rotationSpeed = 360;
        accelBase = 4000;
        maxspeedBase = 8;
		buildCost = 1;
    }

	protected override void Act() {
		base.Act();
		// we need to always do this, even when dead
		// keep canvas below ship
		uiCanvas.transform.position = new Vector3(transform.position.x, .5f, transform.position.z + .5f);
		if (isAlive) {
			// display healthbar
			healthBar.fillAmount = healthCurrent / healthBase;
		} else {
		}
	}

	public virtual void AddHealth(float amount) {
		healthBase += amount;
	}

	protected void PointTowards(Vector3 target) {
		// rotation
		targetRotation = Quaternion.LookRotation(target - new Vector3(transform.position.x, 0, transform.position.z));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
	}

}
