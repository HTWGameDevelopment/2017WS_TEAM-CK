using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {

	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text distanceText;
	[SerializeField]
	private Text timeText;

	private GameManager gameManager;

	// Use this for initialization
	void Start(){
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update(){
		if (!gameManager.getGameStatus ()) {
			printDistance ();
			printTime();
		}
	}

	void FixedUpdate(){
		printScore();
	}

	/// <summary>
	/// This Method will cast the score from the GameManager Object in an String to be printed on the Screen.
	/// </summary>
	public void printScore()
	{
		scoreText.text = "Score: " + gameManager.getScore().ToString();
	}

	/// <summary>
	/// This Method will cast the distance from the GameManager Object in an String to be printed on the Screen.
	/// </summary>
	public void printDistance()
	{
		distanceText.text = "Distance: " + gameManager.getDistance().ToString();
	}

	/// <summary>
	/// This Method will cast the time from the GameManager Object in an String to be printed on the Screen.
	/// </summary>
	public void printTime()
	{
		timeText.text = "Time: " + gameManager.getTime().ToString();
	}
}

