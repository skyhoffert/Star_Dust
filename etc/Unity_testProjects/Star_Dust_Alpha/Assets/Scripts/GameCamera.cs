using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour {

	// this will be the player's ship's tramsform
	private Transform target;
	private float cameraDistance;
	private float zoomSpeed;
	private float minFOV, maxFOV;
	private Vector3 cameraTarget;
	public bool isAttached = true;

	// Use this for initialization
	void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		cameraDistance = 7f;
		zoomSpeed = 10f;
		minFOV = 8;
		maxFOV = 40;
		GetComponent<Camera>().fieldOfView = 20;
		// lock the cursor on the screen
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	// Update is called once per frame
	void FixedUpdate() {
		CameraControl();
		if (Input.GetButton("RestartLevel")) {
			SceneManager.LoadScene("Resources/Scenes/TestScene");
		}
	}

	private void CameraControl() {
		if (Input.GetButtonUp("ToggleCamera")) {
			Toggle();
		}
		if (isAttached) {
			cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z - cameraDistance);
			transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
		} else {
			float diffX = (Input.mousePosition.x > Screen.width * 7 / 8) ? 10 : (Input.mousePosition.x < Screen.width * 1 / 8) ? -10 : 0;
			float diffY = (Input.mousePosition.y > Screen.height * 7 / 8) ? 10 : (Input.mousePosition.y < Screen.height * 1 / 8) ? -10 : 0;
			transform.Translate(new Vector3(diffX * Time.deltaTime, diffY * Time.deltaTime));
		}
		if (Mathf.Abs(Input.mouseScrollDelta.y) > 0) {
			this.GetComponent<Camera>().fieldOfView -= Mathf.Sign(Input.mouseScrollDelta.y) * zoomSpeed / 8;
			if (this.GetComponent<Camera>().fieldOfView > maxFOV) {
				this.GetComponent<Camera>().fieldOfView = maxFOV;
			} else if (this.GetComponent<Camera>().fieldOfView < minFOV) {
				this.GetComponent<Camera>().fieldOfView = minFOV;
			}
		}
	}

	public void Toggle() {
		isAttached = !isAttached;
		// jump to the position if it was just attached
		if (isAttached) {
			cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z - cameraDistance);
			transform.position = cameraTarget;
		}
	}
}
