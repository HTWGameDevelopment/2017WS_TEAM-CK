﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer; 

	public float cameraSpeed;
	private Vector3 lastPlayerPosition; 
	private float distanceToMove;
	public Rigidbody2D myCamera;

	// Use this for initialization
	void Start () {

		myCamera = GetComponent<Rigidbody2D> ();
		//thePlayer = FindObjectOfType<PlayerController> ();
		//lastPlayerPosition = thePlayer.transform.position; 

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


		myCamera.velocity = new Vector2 (cameraSpeed,0);
//		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; 
//		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
//
//		lastPlayerPosition = thePlayer.transform.position; 
	}
}
