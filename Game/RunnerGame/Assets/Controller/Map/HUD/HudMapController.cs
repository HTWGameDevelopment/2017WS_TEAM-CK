using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudMapController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text distanceText;

    private GameManager gameManager;

    // Use this for initialization
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update(){
    }

    void FixedUpdate(){
        printScore();
//            currentTime = (int)Time.time - currentTime;
//            tookTime = true;
    }
    /*
    public void InitializeTimer()
    {
        tookTime = false;
        currentTime = (int)Time.time;
    }*/

    /// <summary>
    /// This Method should cast the score from the GameManager Object in an String to be printed on the Screen.
    /// </summary>
    public void printScore()
    {
        scoreText.text = "Score: " + gameManager.getScore().ToString();
    }

    /// <summary>
    /// This Method should cast the distance from the GameManager Object in an String to be printed on the Screen.
    /// </summary>
    public void printDistance()
    {
        distanceText.text = "Distance: " + gameManager.getCameraPositionX().ToString();
    }
}

