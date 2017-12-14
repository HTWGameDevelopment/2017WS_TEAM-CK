using System.Collections;
using UnityEngine;


public class HealthBar : MonoBehaviour{

	// textures
	public Texture2D healthBackground; // back segment
	public Texture2D healthForeground; // front segment
	public Texture2D healthDamage; // draining segment

	//values
	private float healthBarWidth; //a value for creating the health bar size
	public static int curHP; // current HP
	public static int maxHP = 4; // maximum HP

	void Start () {
		curHP = maxHP;
		healthBarWidth = 100f; // create the health bar value
	}

	void Update(){
		performHealthBar();
	}

	public void performHealthBar(){
	}

	void OnGUI () {
		int posX = 5;
		int posY = 5;
		int height = 15;

		float percentage = healthBarWidth * (curHP/maxHP);

		GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       

		GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth*2), height), healthDamage);

		GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
	}
}