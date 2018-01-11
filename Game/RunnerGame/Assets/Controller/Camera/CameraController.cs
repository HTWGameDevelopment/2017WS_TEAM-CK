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
	private bool cameraMoves;
	public Rigidbody2D myCamera;
	[SerializeField]
	private GameManager gameManager;

    // Use this for initialization
    void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		myCamera = GetComponent<Rigidbody2D> ();
		toggleCameraMovement (false);
		speedMultiplier = 1;
		cameraMoves = false; 

	}

    // Update is called once per frame
	void FixedUpdate () {
		
		// Move Camera
		moveCamera ();
    }

	void Update() {
		checkGameStatusAndStartGame ();	

	}

	/// <summary>
	/// Checks the game status and start game. Gamestatus is handled by the GameManager.
	/// </summary>
	void checkGameStatusAndStartGame(){
		if (gameManager.getGameStatus () && !cameraMoves) {
			toggleCameraMovement (gameManager.isPlayerAlive());
			cameraMoves = true; 

		}
	}

	/// <summary>
	/// Toggles the camera movement. When the player dies, the Camera will stop. 
	/// </summary>
	/// <param name="shouldMove">If set to <c>true</c> should move.</param>
	void toggleCameraMovement(bool shouldMove) {
		if (shouldMove) {
			cameraSpeed = 3.5f * speedMultiplier;
		} else {
			cameraSpeed = 0.0f;
		}
	}


	/// <summary>
	/// Gets the speed. The method is called from the GameManager and grants access to the camera Speed.
	/// </summary>
	/// <returns>The speed.</returns>
    public float getSpeed() {
        return cameraSpeed;
    }

	/// <summary>
	/// Moves the camera. The actual function that moves the camera.
	/// Needs access to the RidgedBody of the Camera.
	/// </summary>
	private void moveCamera(){
		myCamera.velocity = new Vector2 (cameraSpeed, 0);
	}

}
