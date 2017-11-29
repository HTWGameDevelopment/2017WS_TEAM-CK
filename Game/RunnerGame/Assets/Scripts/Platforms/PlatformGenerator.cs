using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform; 
	public Transform generationPoint; 
	public float distanceBetween;

	private float platformWidth; 

	public float distanceBetweenMin; 
	public float distanceBetweenMax;



	public GameObject[] thePlatforms; 
	private int platformSelector; 
	private float[] platformWidths; 
	private int gapChoice; 

	public GameObject lastPlatform; 
	//public ObjectPooler theObjectPool; 

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		platformWidths = new float[thePlatforms.Length];

		for(int i = 0; i < thePlatforms.Length; i++){
			platformWidths[i] = thePlatforms [i].GetComponent  <BoxCollider2D>().size.x; 
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			gapChoice = Random.Range (0, 5);

			switch((int) lastPlatform.GetComponent<BoxCollider2D>().size.y){
			case 2:
				platformSelector = Random.Range (1,4);
				break; 
			case 3: 
				platformSelector = Random.Range (1,4);
				break; 
			case 4: 
				platformSelector = Random.Range (2,5);
				break;
			case 5: 
				platformSelector = Random.Range (3,5);
				break;
			default:
				platformSelector = Random.Range (0, 4);
				break;
			}


			if (gapChoice < 4) {	
				transform.position = new Vector3 (transform.position.x + platformWidths [platformSelector], transform.position.y, 0); 
			} else {
				transform.position = new Vector3 (transform.position.x + platformWidths [platformSelector] + distanceBetween, transform.position.y, 0);
			}


			Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);

			lastPlatform = thePlatforms[platformSelector];
//			GameObject newPlatform = theObjectPool.GetPooledObject ();
//			newPlatform.transform.position = transform.position; 
//			newPlatform.transform.rotation = transform.rotation; 
//			newPlatform.SetActive (true);

		}
		
	}
}
