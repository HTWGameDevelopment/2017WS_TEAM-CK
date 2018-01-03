using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	[SerializeField]
    private float cameraSpeed;
	[SerializeField]
	private float speedMultiplier;
	private bool started; 
	public Rigidbody2D myCamera;


    // Use this for initialization
    void Start () {
		myCamera = GetComponent<Rigidbody2D> ();
		toggleCameraMovement (false);
		speedMultiplier = 1;
		started = false;
	}

    // Update is called once per frame
	void FixedUpdate () {
		
		// Move Camera
		myCamera.velocity = new Vector2 (cameraSpeed, 0);
    }

	void Update() {
		
		// start camera movement if player presses any key
		if (Input.anyKeyDown && !started) {
			toggleCameraMovement (true);
			started = true;
		}
	}

	void toggleCameraMovement(bool shouldMove) {
		if (shouldMove) {
			cameraSpeed = 3.5f * speedMultiplier;
		} else {
			cameraSpeed = 0.0f;
		}
	}

    public float getSpeed() {
        return cameraSpeed;
    }



}
