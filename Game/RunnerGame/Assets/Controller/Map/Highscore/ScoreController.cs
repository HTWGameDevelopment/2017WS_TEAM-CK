using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	[SerializeField]
	private int score;
	[SerializeField]
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		startCalculatingScore ();
	}

	/// <summary>
	/// Starts the calculating score. Invoked when the game starts. 
	/// </summary>
	private void startCalculatingScore(){
		if(gameManager.getGameStatus ()){
			score += 1;
			//Debug.Log ("Score:  " + score);
		}
	}

    /// <summary>
    /// Invoked when the Value of Score need to be called 
    /// </summary>
	public int getScore() {
		return score;
	}

    /// <summary>
    /// Invoked when Player gain extra points 
    /// </summary>
    public void addScore(int value)
    {
        score += value;
    }
}
