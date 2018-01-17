using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private CameraController cameraController;
	private PlayerController playerController;
	[SerializeField]
	private ScoreController scoreController;
	private PlatformGenerator platformGenerator;
	private bool started; 


	private User currentUser = new User("Dummy");


	// Use this for initialization
	void Start () {
		cameraController = FindObjectOfType<CameraController> ();
		playerController = FindObjectOfType<PlayerController> ();
		scoreController = FindObjectOfType<ScoreController> ();
		platformGenerator = FindObjectOfType<PlatformGenerator> ();
		started = false; 
	}
	
	// Update is called once per frame
	void Update () {
		GameStatus ();
	}

	/// <summary>
	/// Gets the camera speed. Method for other scripts to accedd the camera speed.
	/// </summary>
	/// <returns>The camera speed.</returns>
	public float getCameraSpeed() {
		return cameraController.getSpeed ();
	}


	/// <summary>
	/// Gets the player speed. Method for other scritps to access the Speed. 
	/// </summary>
	/// <returns>The player speed.</returns>
	public float getPlayerSpeed() {
		return playerController.getSpeed ();
	}

	/// <summary>
	/// Gets the score. Method for other scripts to accedd the current Score.
	/// </summary>
	/// <returns>The score.</returns>
	public int getScore() {
		return scoreController.getScore ();
	}



	/// <summary>
	/// Function that checks, if the player does any input to start the game. 
	/// </summary>
	private void GameStatus(){
		if (Input.anyKeyDown && !started) {
			started = true;
		}
		if (!isPlayerAlive ()) {
			started = false;		
		}
	}

	/// <summary>
	/// Gets the game status. Any Script that has the GameManger can access these resources. 
	/// </summary>
	/// <returns><c>true</c>, if game status was gotten, <c>false</c> otherwise.</returns>
	public bool getGameStatus(){
		return this.started;
	}

	public bool isPlayerAlive(){
		return playerController.isPlayerAlive ();
	}


	/// <summary>
	/// Games the over. When the player dies, his score will be written to his UserAccount.
	/// All other values like started, alive etc need to be resetted for the next game. 
	/// OR we reset all values in the start method. Needs to be discussed
	/// </summary>
	private void gameOver(){
		currentUser.setScore (scoreController.getScore ());
		// Reset now all values for the next start. 
	}


	public GameObject getLastPlatform(){
		return platformGenerator.getLastPlatform ();
	}

	public void addPointsFromCollectable(int points){
		scoreController.addPointsFromCollectable (points);
	}
}
