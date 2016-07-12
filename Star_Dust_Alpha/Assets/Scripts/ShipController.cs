using UnityEngine;
using System.Collections;

public class ShipController : Ship {

    // control variables
    private Camera cam;

    // the gun!
    public StandardLaserGun cannon;

	// player stats
	// adjusted health for after passives and actives
	protected float healthAdjusted;
	// same sort of layout for power, accel, and velocity
	protected float powerBase, powerCurrent, powerAdjusted;
	protected float accelCurrent, accelAdjusted;
	// current velocity is in the rigid body elements
	protected float maxspeedAdjusted;

    protected override void Initialize() {
        base.Initialize();

		rotationSpeed = 240;

		healthBase = 500;
		healthAdjusted = healthBase;
        healthCurrent = healthAdjusted;

		powerBase = 100;
		powerAdjusted = powerBase;
		powerCurrent = powerAdjusted;

		accelAdjusted = accelBase;
		accelCurrent = accelAdjusted;

        cam = Camera.main;
		// move camera
		cam.transform.position = new Vector3(transform.position.x, 20, transform.position.z - 60);
    }

    protected override void Act() {
        base.Act();
        if (isAlive)
        {
            PointTowardsMouse();
            SetVel();
            CannonManager();
			ApplyDamage(3f);
        } else {
			Destroy(gameObject);
		}
    }

    private void PointTowardsMouse()
    {
        // rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    }

    private void SetVel()
    {
        if (Input.GetButton("MoveForward"))
        {
            Vector3 direction = new Vector3(transform.forward.x, 0f, transform.forward.z);
            direction = direction.normalized;
            direction *= accelCurrent * Time.deltaTime;
            rigidBody.AddForce(direction);
        }
    }

    protected void CannonManager(){

        if (Input.GetButton("Fire"))
        {
            cannon.Shoot();
        }
        else if (Input.GetButtonDown("Fire"))
        {
            cannon.FireContinuous();
        }
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hasCollided = true;
    }
}
