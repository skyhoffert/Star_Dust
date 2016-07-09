using UnityEngine;
using System.Collections;

public class ShipController : Ship {

    // control variables
    private Camera cam;

    // the gun!
    public StandardCannon cannon;

    // Use this for initialization
    void Start () {
        Initialize();
    }

    protected override void Initialize() {
        base.Initialize();
        healthBase = 500;
        healthCurrent = healthBase;
        cam = Camera.main;
    }

    protected override void Act() {
        base.Act();
        if (isAlive)
        {
            PointTowardsMouse();
            SetVelRMBDown();
            CannonManager();
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
            Vector3 direction = new Vector3(transform.forward.x, 0f, transform.forward.z);
            direction = direction.normalized;
            direction *= standardAccel * Time.deltaTime;
            //rigidBody.velocity += direction;
            rigidBody.AddForce(direction);
            //rigidBody.velocity = (rigidBody.velocity.magnitude > maxSpeed) ? rigidBody.velocity.normalized * maxSpeed : rigidBody.velocity;
        }
    }

    protected void CannonManager(){

        if (Input.GetButton("Fire"))
        {
            cannon.Fire();
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
