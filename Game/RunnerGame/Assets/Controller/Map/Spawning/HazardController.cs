using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{

    private GameManager gameManager;
    public Transform generationPoint;
    private float force = 500;
    public GameObject hazards;

    private int spawnChance;
    private int qualifier;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Random.InitState((int)Time.time);
        qualifier = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnHazard();
    }


    /// <summary>
    /// 
    /// </summary>
    public void spawnHazard()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            spawnChance = Random.Range(0, 1000);
            //Debug.Log ("SpawnChance:  " + spawnChance);
            if (gameManager.getScore() % 500 == 0)
            {
                qualifier++;
            }
            if (spawnChance <= qualifier)
            {
                transform.position = new Vector2(generationPoint.position.x + 1, generationPoint.position.y);
                var clone = Instantiate(hazards, transform.position, transform.rotation);
                clone.AddComponent<Rigidbody2D>();
                clone.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                //Relative postion from player to camera
                var player_to_cam = new Vector2(gameManager.getPlayerPositionX(), gameManager.getPlayerPositionY());
                //Relative postion from spawnPoint to player
                var gen_to_player = player_to_cam - (Vector2)transform.position;
                //Debug.Log ("Score:  " + player_to_cam);
                clone.GetComponent<Rigidbody2D>().AddForce(gen_to_player.normalized * force);

            }
        }
    }
}