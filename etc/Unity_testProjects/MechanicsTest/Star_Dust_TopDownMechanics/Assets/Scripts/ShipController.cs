using UnityEngine;
using System.Collections;

public class ShipController : Ship {

    // control variables
    private Camera cam;

    public StandardCannon cannon;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        standardAccel = 5f;
        maxSpeed = 10;
        health = 500;
        isAlive = true;
        hasCollided = false;
        rotationSpeed = 360;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            PointTowardsMouse();
            SetVelRMBDown();
            MoveByVel();
            FireCannon();
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

    private void SetVelRMBDown()
    {
        if (Input.GetButton("MoveForward"))
        {
            Vector3 direction = transform.forward;
            direction = direction.normalized;
            direction *= standardAccel * Time.deltaTime;
            velocity += direction;
            velocity = (velocity.magnitude > maxSpeed) ? velocity.normalized * maxSpeed : velocity;
        }
    }

    protected new void MoveByVel()
    {
        if (!hasCollided)
        {
            // call super class method
            base.MoveByVel();
        } else
        {
            velocity = new Vector3(0, 0, 0);
            hasCollided = false;
        }
    }

    protected void FireCannon(){

        if (Input.GetButton("Shoot"))
        {
            cannon.Fire();
        }
        else if (Input.GetButtonDown("Shoot"))
        {
            cannon.FireContinuous();
        }
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hasCollided = true;
    }
}
