using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Der HighscoreController is in this context meant to be an DataController for your Highscores
 */
public class HighscoreController : MonoBehaviour
{
    private int[] allHighscores;

    private int score = 0;

    public void addScore(int newScoreValue)
    {
        score += newScoreValue;
    }
    
    public int getScore()
    {
        return score;
    }

    public void setScore(int score)
    {
        this.score = score;
    }
    

    public int[] getAllScores()
    {
        return allHighscores;
    }
}