using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class StandardLaserGun : MonoBehaviour {

	// this is where the gun is
    public Transform spawn;
	// for the tracer
	private LineRenderer tracer;
	// sounds!
	private AudioSource audioSource;
	public AudioClip firingSound;
	// stats
    private float shotDistance;
    private float shotsPerMinute;
    private float secondsBetweenShots;
    private float nextPossibleShootTime;
	private float tracerDuration;
	// firing type
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
		tracerDuration = secondsBetweenShots / 2;
		// set the tracer, if it exists
		if (GetComponent<LineRenderer>()) {
			tracer = GetComponent<LineRenderer>();
		}
		// set audio stuff
		audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        // do nothing
	}

    // when we want to fire the cannon
    public void Shoot()
    {
        if (CanShoot())
        {
            shotDistance = 20f;

			// collision stuff
			// this is instant!
            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, shotDistance)) {
                shotDistance = hit.distance;
                if (hit.collider.GetComponent<Entity>()) {
                    hit.collider.GetComponent<Entity>().ApplyDamage(damage);
                }
            }
			// set next time to shoot
            nextPossibleShootTime = Time.time + secondsBetweenShots;

			// draw the tracer, if it exists
			if (tracer) {
				StartCoroutine("RenderTracer", ray.direction * shotDistance);
			}

			// play the audio
			audioSource.clip = firingSound;
			audioSource.Play();

            // for debugging
            // Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red, 1);
        }
    }

	// coroutine for rendering the tracer
	IEnumerator RenderTracer(Vector3 hitPoint) {
		tracer.enabled = true;
		tracer.SetPosition(0, spawn.position);
		tracer.SetPosition(1, spawn.position + hitPoint);
		yield return new WaitForSeconds(tracerDuration);
		tracer.enabled = false;
	}

    public void FireContinuous()
    {
        if (firingType == FiringType.AUTO)
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextPossibleShootTime;
    }
}
