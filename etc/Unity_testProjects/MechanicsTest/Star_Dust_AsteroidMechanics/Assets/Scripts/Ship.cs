using UnityEngine;
using System.Collections;

public class Ship : Entity {

    // rotation
    // where the ship should point
    protected Quaternion targetRotation;

    // ship stats
    protected bool hasCollided;
    // the speed that the player can rotation in degrees / second
    public float rotationSpeed;
    // other speeds
    public float standardAccel;
    public float maxSpeed;

    // Use this for initialization
    void Start ()
    {
        Initialize();
    }

    protected override void Initialize() {
        // initialize base stuff
        base.Initialize();
        hasCollided = false;
        rotationSpeed = 360;
        standardAccel = 5000;
        maxSpeed = 8;
    }
}
