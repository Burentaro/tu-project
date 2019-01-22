using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public bool active = true;
	public float speed = 20;

	private Transform objectsTransform;
	private bool movementActivated = false;
	private float rightAxis = 0, forwardAxis = 0;


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
			}
			if (Input.GetMouseButtonUp (1)) {
				movementActivated = false;
			}

			// Lateral Movement
			if(Input.GetButtonDown(KeyCode.D)){
				rightAxis = 1;
			}
			if (Input.GetButtonDown (KeyCode.A)) {
				rightAxis = -1;
			}

			// Frontal movement
			if (Input.GetButtonDown (KeyCode.W)) {
				forwardAxis = 1;
			}
			if (Input.GetButtonDown (KeyCode.S)) {
				forwardAxis = -1;
			}

			// Move
			if (movementActivated) {
				move ();
			}
		}
	}

	private void move(){
		
	}
}
