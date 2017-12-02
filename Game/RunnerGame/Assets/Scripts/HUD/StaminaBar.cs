using System.Collections;
using UnityEngine;


public class StaminaBar : MonoBehaviour{
	
	// textures
	public Texture2D staminaBackground; // back segment
	public Texture2D staminaForeground; // front segment
	public Texture2D staminaDamage; // draining segment
	public GUIStyle HUDSkin; // Styles up the health integer

	//values
	private float staminaBarWidth; //a value for creating the health bar size
	private float myFloat; // an empty float value to affect drainage speed
	public static float curSt; // current HP
	public static float maxSt = 100f; // maximum HP

	void Start () {
		curSt = maxSt;
		staminaBarWidth = 100f; // create the health bar value
	}

	void Update(){
		performStaminaBar();
	}

	public void performStaminaBar(){
	}

	void OnGUI () {
		int posX = 5;
		int posY = 20;
		int height = 15;

		float percentage = staminaBarWidth * (curSt/maxSt);

		GUI.DrawTexture (new Rect (posX, posY, (staminaBarWidth * 2), height), staminaBackground);       

		GUI.DrawTexture (new Rect (posX, posY, (staminaBarWidth*2), height), staminaDamage);

		GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), staminaForeground);

		//HUDSkin = new GUIStyle();
	}
}