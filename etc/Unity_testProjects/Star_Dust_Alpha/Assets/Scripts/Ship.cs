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
    protected float standardAccel;
    protected float maxSpeed;

	public Canvas uiCanvas;
	public Image healthBar;

    // Use this for initialization
    void Start ()
    {
        Initialize();
    }

    protected override void Initialize() {
        // initialize base stuff
        base.Initialize();
		healthBase = 100;
		healthCurrent = healthBase;
        hasCollided = false;
        rotationSpeed = 360;
        standardAccel = 4000;
        maxSpeed = 8;
    }

	void Update() {
		Act();
	}

	protected override void Act() {
		base.Act();
		if (isAlive) {
			// keep canvas below ship
			uiCanvas.transform.position = new Vector3(transform.position.x, 0, transform.position.z - .75f);
			// display healthbar
			healthBar.fillAmount = healthCurrent / healthBase;
		} else {
			// remove the other ui elements
			Destroy(uiCanvas.gameObject);
			Destroy(healthBar.gameObject);
		}
	}

	protected void PointTowards(Vector3 target) {
		// rotation
		targetRotation = Quaternion.LookRotation(target - new Vector3(transform.position.x, 0, transform.position.z));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
	}

}
