using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawning : MonoBehaviour
{
    public int timer, frameCount;
    public int SpeedUp, spawning, NumToSpawn;
    bool spawnTime;
    public int HeartId, HeartSpawn;
    public GameObject Heart;
    public GameObject Player;
    Player play;
    GameManager game;

    float positionX, positionY;
    string state;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        frameCount = 60;
        HeartId = 1;

        NumToSpawn = 0;
        spawning = 0;

        play = GameObject.Find("Player").GetComponent<Player>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        positionX = Random.Range(-14f, 14f);
        positionY = Random.Range(-7f, 7f);
        HeartPick();
    }

    public void HeartPick()
    {
        HeartSpawn = Random.Range(1, 4);
        switch(HeartSpawn)
        {
            case 1: 
                NumToSpawn = 1;
                break;
            case 2:
                NumToSpawn = 2;
                break;
            case 3:
                NumToSpawn = 3;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (game.state == "play")
        {
            if (spawning != NumToSpawn)
            {
                frameCount -= 1;
                if (frameCount <= 0)
                {
                    GameObject newHeart = Instantiate(Heart, new Vector3(positionX, positionY), Quaternion.identity);
                    newHeart.name = HeartId.ToString();
                    newHeart.transform.parent = GameObject.Find("HeartContainer").GetComponent<Transform>();
                    HeartId++;
                    spawning++;
                    positionX = Random.Range(-14f, 14f);
                    positionY = Random.Range(-7f, 7f);
                    frameCount = 60;
                }
            }
        }
    } 
}
