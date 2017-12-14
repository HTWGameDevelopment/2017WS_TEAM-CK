using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudMapController : MonoBehaviour
{
    private HighscoreController playerScore;
    private int currentScore;

    private PlayerController player;
    private CameraController mainCamera;


    public Text scoreText;
    public Text timeText;
    

    // Use this for initialization
    void Start()
    {
        playerScore = FindObjectOfType<HighscoreController>();
        currentScore = playerScore.getScore();

        player = FindObjectOfType<PlayerController>();
        mainCamera = FindObjectOfType<CameraController>();

        InitializeHud();
    }

    // Update is called once per frame
        void Update()
        {   
        }

    void FixedUpdate()
    {
        updateScore();

        if (player.isAlive == true && mainCamera.start == true)
        {
            playerScore.addScore(1);
        }

        currentScore = playerScore.getScore();
    }

    public void InitializeHud()
    {
        InitializeScore();
        InitializeHealthBar();
        InitializeStaminaBar();
    }

    public void InitializeScore()
    {
        playerScore.setScore(0);
    }

    public void InitializeHealthBar()
    {
    }

    public void InitializeStaminaBar()
    {
    }

    public void updateScore()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

 
}

