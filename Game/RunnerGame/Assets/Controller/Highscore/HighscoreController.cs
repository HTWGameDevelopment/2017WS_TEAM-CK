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

    private int score;
    private int distance;

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

    public void setDistance(int distance)
    {
        this.distance = distance;
    }

    public int getDistance()
    {
       return distance;
    }


    public int[] getAllScores()
    {
        return allHighscores;
    }


}