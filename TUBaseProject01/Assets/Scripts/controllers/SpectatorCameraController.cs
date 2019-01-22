using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorCameraController : MonoBehaviour {
	public bool active = true;
	public float speed = 0.5f;
    public float rotationSpeed = 2;

	public Transform objectsTransform;
	private bool movementActivated = false;
	private float rightAxis = 0, forwardAxis = 0, upAxis = 0, yaw = 0, pitch = 0;


	// Use this for initialization
	void Start () {
		objectsTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			// Activate/deactivate movemente with right click
			if (Input.GetMouseButtonDown (1)) {
				movementActivated = true;
                Cursor.visible = false;
			}
			if (Input.GetMouseButtonUp (1)) {
				movementActivated = false;
                Cursor.visible = true;
            }

            // Lateral Movement
            rightAxis = Input.GetAxis("Horizontal");

            // Frontal movement
            forwardAxis = Input.GetAxis("Vertical");

            // Up and Down movement
            upAxis = Input.GetAxis("UpDown");

            // Mouse vertical
            pitch = rotationSpeed * Input.GetAxis("Mouse Y");

            // Mouse horizontal
            yaw = rotationSpeed * Input.GetAxis("Mouse X");

			// Move
			if (movementActivated) {
				move ();
			}
		}
	}

	private void move(){
        objectsTransform.Translate(new Vector3(speed * rightAxis, speed * upAxis, speed * forwardAxis));
        if (pitch > yaw)
        {
            objectsTransform.Rotate(-pitch, 0, 0);
        }
        else
        {
            objectsTransform.Rotate(0, yaw, 0);
        }
        
    }
}
