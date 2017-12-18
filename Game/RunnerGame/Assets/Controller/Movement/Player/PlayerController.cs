using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed ; 
	public float jumpForce ; 

	private Rigidbody2D myRigidbody;
    private HudMapController hudMap;


	public bool grounded;
	public bool isAlive;
    public bool gameIsRunning;

    public Animator animator;
	public LayerMask whatIsGround;
	public Rigidbody2D myCamera;
	public CameraController mainCamera; 
	private Collider2D myCollider; 
	private bool wantsToJump = false;

	// Use this for initialization
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
		isAlive = true;
		myCollider = GetComponent<Collider2D> (); 
		mainCamera = FindObjectOfType<CameraController> ();
		moveSpeed = mainCamera.getCameraSpeed() * 1.5f ;
	    jumpForce = 20;


	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
			wantsToJump = true;
		}

		//Code has to be placed here, because if its in FixedUpdate it produces an Bug when selecting a new game and pressing and holding a Key befor
		if (Input.anyKeyDown) { 
			mainCamera.start = true;
		}


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
        
		moveSpeed = mainCamera.getCameraSpeed() *1.2f ;

		if (GameObject.Find("Player").transform.position.y <=-4) {
			isAlive = false;
		    mainCamera.end = true;
		}
	

	    var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
	    this.transform.Translate(x, 0, 0);
        // Vertricale bewegung
        // var z = Input.GetAxis("Vertical") * Time.deltaTime * jumpForce;
        // this.transform.Translate(z,0,0);

	    if (x != 0)
	    {
	        animator.SetBool("Walking", true);
	    }else
	    {
	        animator.SetBool("Walking", false);
        }

	    if (wantsToJump){
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
			wantsToJump = false;
		}
	}
}
