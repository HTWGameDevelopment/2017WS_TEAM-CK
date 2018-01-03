using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private CameraController camera;
	private PlayerController player;
	private ScoreController score;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<CameraController> ();
		player = FindObjectOfType<PlayerController> ();
		score = FindObjectOfType<ScoreController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float getCameraSpeed() {
		return camera.getSpeed ();
	}

	public float getPlayerSpeed() {
		return player.getSpeed ();
	}

	public int getScore() {
		return score.getScore ();
	}
}
