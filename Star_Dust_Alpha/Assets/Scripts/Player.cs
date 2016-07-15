using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// the player's ship
	public PlayerShip playerShip;
	// control variables
	private Camera cam;

	// if the player is being built
	private bool isBeingBuilt;

	// death timer
	private float deathTimer;

	// a ground plane, for mouse pointer location on the ground plane
	Plane plane;
	// for what the mouse ray collides with
	Collider mousePointCollider;

	// Use this for initialization
	void Start () {
		deathTimer = 2;
		isBeingBuilt = false;

		plane = new Plane(Vector3.up, 0);
		mousePointCollider = null;

		// camera stuff
		cam = Camera.main;
		// move camera
		cam.transform.position = new Vector3(playerShip.transform.position.x, 20, playerShip.transform.position.z - 60);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerShip) {
			if (playerShip.getIsAlive()) {
				isBeingBuilt = false;

				// rotation for ship
				Vector3 mousePos = new Vector3(0, 0, 0);
				// temp distance
				float dist;
				// ray casting from camera to ground place
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				// get where it contacts
				if (plane.Raycast(ray, out dist)) {
					mousePos = ray.GetPoint(dist);
				}
				playerShip.PointTowardsMouse(mousePos);

				ClickManager();
				DisplayAbilities();
				DisplayItems();
			} else {
				if (!isBeingBuilt) {
					isBeingBuilt = true;
					GameObject.FindGameObjectWithTag("StarShip").GetComponent<StarShip>().BuildNewPlayer(playerShip.buildCost, deathTimer);
				}
			}
		} else {
		}
	}

	// this controls if something is clicked
	private void ClickManager() {
		if (mousePointCollider) {
			if (Input.GetButtonDown("Fire")) {
				if (mousePointCollider.GetComponent<StarShip>()) {
					//playerShip.IgnoreFireClick();
				}
			}
		}
	}

	private void DisplayAbilities() {
		
	}

	private void DisplayItems() {

	}

}
