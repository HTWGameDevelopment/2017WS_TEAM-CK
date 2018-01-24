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

	#if UNITY_STANDALONE || UNITY_STANDALONE_WIN
	public float detectHorizontalKey() {
		float input = Input.GetAxis ("Horizontal");
		return (input != 0) ? input : 0;
	}

	public bool detectJump() {
		float input = Input.GetAxis ("Jump");
		return (input != 0) ? true : false;
	}

	#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
	public bool detectJump() {
		float Input = Input.GetTouch(0).phase == TouchPhase.Began;
		return (input != 0) ? true : false;
	}

	#endif
}
