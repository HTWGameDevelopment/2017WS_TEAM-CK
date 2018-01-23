using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	private GameObject DestructionPoint; 


	// Use this for initialization
	void Start () {
		DestructionPoint = GameObject.Find ("DestructionPoint");

    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < DestructionPoint.transform.position.x){
			Destroy (gameObject);
		    //gameObject.SetActive (false);
		}
	}

}
