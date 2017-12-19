using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreController : MonoBehaviour {

	private int score;
	private int distance;

	// Use this for initialization
	void Start () {
		score = 0;
		distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore(int value) {
		score += value;
	}

	public int getScore() {
		return score;
	}

	public int getDistance() {
		return distance;
	}
}
