using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public bool jump;

	// Use this for initialization
	void Start () {
		jump = false;
	}
	
	// Update is called once per frame
	void Update () {
		jump = detectJump ();
    }

	public float detectHorizontalKey() {
		float input = Input.GetAxis ("Horizontal");
		return (input != 0) ? input : 0;
	}

	public bool detectJump() {
		float input = Input.GetAxis ("Jump");
		return (input != 0) ? true : false;
	}
}
