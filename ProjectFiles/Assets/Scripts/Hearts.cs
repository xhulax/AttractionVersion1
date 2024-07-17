using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    GameManager game;
    public GameObject Heart;
    public HeartSpawning heartsSpawn;
    public Player play;
    SpriteRenderer player,hearts;
    Color thisColour;

    float positionX, positionY;
    string state;
    bool collect, spawnTime;
    int timer, frameCount, HeartId;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        timer = 5;
        frameCount = 60;
        state = "stationary";
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        play = GameObject.Find("Player").GetComponent<Player>();
        heartsSpawn = GameObject.Find("HeartSpawning").GetComponent<HeartSpawning>();
        hearts = this.GetComponent<SpriteRenderer>();
        spawnTime = true;
        thisColour = this.GetComponent<SpriteRenderer>().color;

    }

    private void OnDestroy()
    {
        if (state == "collect")
        {
            play.Hearts += 1;
            heartsSpawn.spawning -= 1;
            spawnTime = true;
            timer = 5;
            heartsSpawn.frameCount = 120;
        }
        else
        {
            if (heartsSpawn != null) heartsSpawn.spawning -= 1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime == true)
        {
            if (timer >= 0)
            {
                frameCount -= 1;
                if (frameCount <= 0)
                {
                    timer -= 1;
                    frameCount = 60;
                }
            }
            if (timer < 0)
            {
                frameCount = 60;
                timer = 3;
                spawnTime = false;
                Destroy(this.gameObject);
            }
        }
        if (hearts.bounds.Intersects(player.bounds) && collect == false)
        {
            state = "collect";
            collect = true;
            Destroy(this.gameObject);
        }   
        if (game.state == "reset" || game.state == "name")
        {
            timer = 5;
            frameCount = 60;
            Destroy(this.gameObject);
        }
    }
}
