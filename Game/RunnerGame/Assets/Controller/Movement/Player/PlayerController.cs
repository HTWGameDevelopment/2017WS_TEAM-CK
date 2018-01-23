﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; 
	public float jumpForce; 
	public int lifepoints; 

	private Rigidbody2D myRigidbody;


	public bool grounded;
	public bool isAlive;
    public bool gameIsRunning;

    public Animator animator;
	public LayerMask whatIsGround;
	public LayerMask deathZone;
	public LayerMask lava; 
	private Collider2D myCollider;
	private bool wantsToJump = false;

	private GameManager gameManager;
	private InputController inputCtrl;

	// Use this for initialization
	void Start ()
	{
		gameManager = FindObjectOfType<GameManager> ();
		inputCtrl = FindObjectOfType<InputController> ();

		myRigidbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<CapsuleCollider2D> (); 
		isAlive = true;
		moveSpeed = gameManager.getCameraSpeed();
	    jumpForce = 20;
		lifepoints = 5;
	}

	void Update () {
		checkPlayerIsAlive ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		checkGrounded ();
		moveSpeed = gameManager.getCameraSpeed () * 1.2f ;
		movePlayer ();

	}

	/// <summary>
	/// Raises the collision enter2 d event, when the player collides with a lava block
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "lava" && lifepoints > 0) {
			lifepoints--;
		}
	}

	void OnTriggerEnter2D(Collider2D collect){
		if(collect.gameObject.CompareTag ("collectable")){
			Destroy (collect.gameObject);
			gameManager.addPointsFromCollectable (100);
		}
		if (collect.gameObject.CompareTag ("cookie")) {
			increaseHealth ();
			Destroy (collect.gameObject);
		}
	}
		

	public float getSpeed() {
		return moveSpeed;
	}

	public bool isPlayerAlive(){
		return this.isAlive;
	}

	/// <summary>
	/// Checks the player is alive.
	/// Later can be shorter -> isAlive = !Physics2D.IsTouchingLayers (myCollider, deathZone)
	/// For testing purpose we need the log statement
	/// </summary>
	private void checkPlayerIsAlive(){
		if (Physics2D.IsTouchingLayers (myCollider, deathZone)) {
			lifepoints = 0;
			isAlive = false;
			//Debug.Log ("Player died! You failed!!!");
		}
		if (lifepoints <= 0) {
			isAlive = false;
		}
	}


	/// <summary>
	/// Moves the player.
	/// </summary>
	private void movePlayer(){
		var x = inputCtrl.detectHorizontalKey() * Time.deltaTime * moveSpeed;
		this.transform.Translate(x, 0, 0);

		if (x != 0) {
			animator.SetBool("Walking", true);
		} else {
			animator.SetBool("Walking", false);
		}

		if (inputCtrl.jump) {
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
			wantsToJump = false;
		}
	}
		
	/// <summary>
	/// Checks if the player is grounded and can jump. 
	/// On normal ground or lava,the player is allowed to jump. 
	/// </summary>
	private void checkGrounded(){
		if (Physics2D.IsTouchingLayers (myCollider, whatIsGround) || Physics2D.IsTouchingLayers (myCollider, lava)) {
			grounded = true;
		} else {
			grounded = false; 
		}
	}

	private void increaseHealth(){
		if(lifepoints < 5){
			lifepoints++;
		}
	}

	/// <summary>
	/// Gets the life points.
	/// </summary>
	/// <returns>The life points.</returns>
	public int getLifePoints() {
		return this.lifepoints;
	}
}
