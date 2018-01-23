﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private CameraController cameraController;
	private PlayerController playerController;
	[SerializeField]
	private ScoreController scoreController;
    private DistanceController distanceController;
    private HudMapController hudMapController;
    private HazardController hazardController;
    private bool started; 
    
	private User currentUser = new User("Dummy");


	// Use this for initialization
	void Start () {
		cameraController = FindObjectOfType<CameraController> ();
		playerController = FindObjectOfType<PlayerController> ();
		scoreController = FindObjectOfType<ScoreController> ();
	    distanceController = FindObjectOfType<DistanceController>();
	    hazardController = FindObjectOfType<HazardController>();

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
    /// Gets the Camera X position. Method for other scritps to access the X. 
    /// </summary>
    /// <returns>The player X.</returns>
    public float getCameraPositionX()
    {
        return cameraController.getPositionX();
    }

    /// <summary>
    /// Gets the Camera Y position. Method for other scritps to access the Y. 
    /// </summary>
    /// <returns>The player speed.</returns>
    public float getCameraPositionY()
    {
        return cameraController.getPositionY();
    }

    /// <summary>
    /// Gets the player X. Method for other scritps to access the X. 
    /// </summary>
    /// <returns>The player speed.</returns>
    public float getPlayerPositionX()
    {
        return playerController.getPositionX();
    }

    /// <summary>
    /// Gets the player Y. Method for other scritps to access the Y. 
    /// </summary>
    /// <returns>The player speed.</returns>
    public float getPlayerPositionY()
    {
        return playerController.getPositionY();
    }

    /// <summary>
    /// Gets the score. Method for other scripts to access the current Score.
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

}
