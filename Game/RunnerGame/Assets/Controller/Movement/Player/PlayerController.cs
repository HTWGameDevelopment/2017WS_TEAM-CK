using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	private bool isAlive;

	private Rigidbody2D myRigidbody;
	public Animator animator;

	public bool grounded;
	public LayerMask whatIsGround;
	public LayerMask catcherLayer;
	public CameraController mainCamera; 
	public InputController inputCtrl;

	private Collider2D myCollider;

	private bool wantsToJump = false;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		mainCamera = FindObjectOfType<CameraController> ();
		inputCtrl = FindObjectOfType<InputController> ();
		moveSpeed = mainCamera.cameraSpeed * 1.5f ;

		isAlive = true;
	}

	void Update () {
		if (inputCtrl.input == KeyCode.Space) {
			wantsToJump = true;
		}

		if (inputCtrl.input == KeyCode.D || inputCtrl.input == KeyCode.A) {
			mainCamera.startCamera ();
		}

		if(!stillAlive()) {
			// Debug.Log ("Player died");
			mainCamera.stopCamera ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		//Debug.Log (mainCamera.cameraSpeed);
		moveSpeed = mainCamera.cameraSpeed *1.2f ;


		//myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
		//myRigidbody.velocity  = mainCamera.myCamera.velocity;

//		if(Input.GetKeyDown (KeyCode.RightArrow)){
//			//myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y) ;
//
//
//		}
		var movement = Input.GetAxisRaw ("Horizontal") * Time.deltaTime *moveSpeed;
		this.transform.Translate (movement, 0, 0);

		if (movement != 0) {
			animator.SetBool ("Walking", true);
		} else {
			animator.SetBool ("Walking", false);
		}
	
//		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
//			myRigidbody.velocity = new Vector2 (-moveSpeed, myRigidbody.velocity.y);
//		}
//

		if(wantsToJump){
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
			wantsToJump = false;
		}
	}

	bool stillAlive() {
		if (Physics2D.IsTouchingLayers (myCollider, catcherLayer)) {
			isAlive = false;
			return false;
		} else {
			return true;
		}
	}
}