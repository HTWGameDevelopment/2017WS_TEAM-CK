using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
	[SerializeField]
	private string name;
	[SerializeField]
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
}
