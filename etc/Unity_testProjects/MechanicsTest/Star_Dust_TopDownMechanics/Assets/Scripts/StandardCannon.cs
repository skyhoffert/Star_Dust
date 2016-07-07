using UnityEngine;
using System.Collections;

public class StandardCannon : MonoBehaviour {

    public Transform spawn;
    private float shotDistance;
    public float shotsPerMinute;
    private float secondsBetweenShots;
    private float nextPossibleShootTime;

    public enum FiringType { SEMI, AUTO };
    public FiringType firingType;
    public int damage;

    // Use this for initialization
    void Start ()
    {
        damage = 35;
        firingType = FiringType.SEMI;
        shotsPerMinute = 300;
        secondsBetweenShots = 60 / shotsPerMinute;
    }
	
	// Update is called once per frame
	void Update () {
        // do nothing
	}

    // when we want to fire the cannon
    public void Fire()
    {
        if (CanShoot())
        {
            shotDistance = 20f;

            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, shotDistance))
            {
                shotDistance = hit.distance;
                if (hit.collider.GetComponent<Ship>())
                {
                    hit.collider.GetComponent<Ship>().ApplyDamage(damage);
                }
                else if (hit.collider.GetComponent<Asteroid>())
                {
                    hit.collider.GetComponent<Asteroid>().ApplyDamage(damage);
                }
            }

            nextPossibleShootTime = Time.time + secondsBetweenShots;

            // for debugging
            Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red, 1);
        }
    }

    public void FireContinuous()
    {
        if (firingType == FiringType.AUTO)
        {
            Fire();
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextPossibleShootTime;
    }
}
