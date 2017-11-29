using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed ; 
	public float jumpForce ; 

	private Rigidbody2D myRigidbody; 

	public bool grounded;
	public LayerMask whatIsGround;
	public CameraController mainCamera; 

	private Collider2D myCollider; 


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		myCollider = GetComponent<Collider2D> (); 
		mainCamera = FindObjectOfType<CameraController> ();
		moveSpeed = mainCamera.cameraSpeed *1.5f ;
		 
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

		this.transform.Translate (Input.GetAxisRaw ("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);
	
//		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
//			myRigidbody.velocity = new Vector2 (-moveSpeed, myRigidbody.velocity.y);
//		}
//

		if(Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0) ){
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
		}
	}

}
