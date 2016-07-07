using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Entity : MonoBehaviour {

    // controller for movement
    protected CharacterController controller;

    // movement
    protected Vector3 velocity;

    // stats
    protected bool isAlive;

    // Use this for initialization
    void Start () {
        isAlive = true;
        velocity = new Vector3(0, 0, 0);
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            MoveByVel();
        }
	}

    // move this controller by the velocity
    protected void MoveByVel()
    {
        if (isAlive)
        {
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
