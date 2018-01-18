using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public LayerMask deathZone;
	private Collider2D myCollider; 
	private bool wantsToJump = false;

	private GameManager gameManager; 

	// Use this for initialization
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
		gameManager = FindObjectOfType<GameManager> ();
		myCollider = GetComponent<Collider2D> (); 
		isAlive = true;
		moveSpeed = gameManager.getCameraSpeed();
	    jumpForce = 20;
	}

	void Update () {
		detectJump ();
		checkPlayerIsAlive ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		moveSpeed = gameManager.getCameraSpeed () *1.2f ;
		movePlayer ();

	}

	public float getSpeed() {
		return moveSpeed;
	}
    /// <summary>
    /// Gets the Position in x direction. 
    /// The method is called from the GameManager and grants access to the player position.
    /// </summary>
    /// <returns>The Position.</returns>
    public float getPosition(){
        return myRigidbody.position.x;
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
			isAlive = false;
			//Debug.Log ("Player died! You failed!!!");
		}
	}


	/// <summary>
	/// Moves the player.
	/// </summary>
	private void movePlayer(){

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

	/// <summary>
	/// Detects the jump. When the customer presses SPACE | W | UP_ARROW, the player will jump.
	/// </summary>
	private void detectJump(){
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
			wantsToJump = true;
		}
	}
}
