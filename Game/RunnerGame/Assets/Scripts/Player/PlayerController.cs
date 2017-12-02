using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed ; 
	public float jumpForce ; 

	private Rigidbody2D myRigidbody; 

	public bool grounded;
	public bool isAlive;
//	public Text countText;

	public LayerMask whatIsGround;
	public Rigidbody2D myCamera;
	public CameraController mainCamera; 
	private Collider2D myCollider; 
	private int count;
	private bool wantsToJump = false;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		isAlive = true;
		count = 0;
		updateScore();
		myCollider = GetComponent<Collider2D> (); 
		mainCamera = FindObjectOfType<CameraController> ();
		moveSpeed = mainCamera.cameraSpeed *1.5f ;


	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			wantsToJump = true;
		}

		//Code has to be placed here, because if its in FixedUpdate it produces an Bug when selecting a new game and pressing and holding a Key befor
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.UpArrow)) { 
			mainCamera.start = true;
		}


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		//Debug.Log (mainCamera.cameraSpeed);
		moveSpeed = mainCamera.cameraSpeed *1.2f ;

		if (isAlive == true && mainCamera.start == true) {
			addScore(1);
		}


		if (GameObject.Find("Player").transform.position.y <=-4) {
			isAlive = false;
			mainCamera.cameraSpeed = 0;
		}
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

		if(wantsToJump){
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
			wantsToJump = false;
		}
	}



	public void addScore (int newScoreValue){
		count = newScoreValue;
		updateScore ();
	}

	public void updateScore(){
	//	countText.text = "Score: " + count.ToString ();

	}
}
