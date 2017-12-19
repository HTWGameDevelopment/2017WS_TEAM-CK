using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudMapController : MonoBehaviour
{
    private HighscoreController playerScores;
    private PlayerController player;
    private CameraController mainCamera;

    private bool tookTime;

    public Text scoreText;
    public Text distanceText;
    public Text timeText;

    private int currentScore;
    private int currentDistance;
    private int currentTime;

    // Use this for initialization
    void Start()
    {
        playerScores = FindObjectOfType<HighscoreController>();
        player = FindObjectOfType<PlayerController>();
        mainCamera = FindObjectOfType<CameraController>();
        InitializeHud();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive == true && mainCamera.start == true)
        {
            currentDistance= (int) player.transform.position.x + ((int)mainCamera.transform.position.x - (int) player.transform.position.x);
            playerScores.setDistance(currentDistance);
        }
    }

    void FixedUpdate()
    {
        if (player.isAlive == true && mainCamera.start == true)
        {
            playerScores.addScore(1);
        }
        if (mainCamera.end == true && tookTime == false)
        {
            currentTime = (int)Time.time - currentTime;
            tookTime = true;
        }

        currentScore = playerScores.getScore();
        currentDistance = playerScores.getDistance();

        updateScore();
        updateDistance();
        updateTime();
    }

    public void InitializeHud()
    {
        InitializeScore();
        InitializeDistance();
        InitializeTimer();
    }

    public void InitializeScore()
    {
       playerScores.setScore(0);
    }

    public void InitializeDistance()
    {
        //Player in dependency of the Camera == 0 every time
        playerScores.setDistance((int)player.transform.position.x + ((int)mainCamera.transform.position.x - (int)player.transform.position.x));
    }


    public void InitializeTimer()
    {
        tookTime = false;
        currentTime = (int)Time.time;
    }

    public void updateScore()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void updateDistance()
    {
        distanceText.text = "Distance: " + currentDistance.ToString();
    }

    public void updateTime()
    {
        timeText.text = "Time alive: " + currentTime.ToString() + " Sec.";
    }
}

