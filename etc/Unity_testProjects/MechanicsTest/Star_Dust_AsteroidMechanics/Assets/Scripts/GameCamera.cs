using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    // this will be the player's ship's tramsform
    private Transform target;
    private int cameraDistance = 3;
    private Vector3 cameraTarget;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z - cameraDistance);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
    }
}
