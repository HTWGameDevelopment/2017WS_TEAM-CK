using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User{
	[SerializeField]
	private string name;
	[SerializeField]
	private int score;
    [SerializeField]
    private int time;
    [SerializeField]
    private int distance;
    [SerializeField]
    private int health;
    [SerializeField]
    private int stamina;

    // Use this for initialization
    void Start () {
		score = 0;
	}

	public User(string name){
		this.setName (name);
		this.setScore (0);
        this.setTime(0);
	    this.setDistance(0);
	    this.setHealth(100);
	    this.setStamina(100);
    }
	public string getName(){
		return this.name; 
	}

	public int getScore(){
		return this.score;
	}

    public int getTime()
    {
        return this.time;
    }

    public int getDistance()
    {
        return this.distance;
    }

    public int getHealth()
    {
        return this.health;
    }

    public int getStamina()
    {
        return this.stamina;
    }

    public void setName(string name){
		this.name = name;
	}

	public void setScore(int score){
		this.score = score;
	}

    public void setTime(int time)
    {
        this.time = time;
    }
    public void setDistance(int distance)
    {
        this.distance = distance;
    }

    public void setHealth(int health)
    {
        this.distance = distance;
    }

    public void setStamina(int stamina)
    {
        this.distance = distance;
    }
}
