using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSpawning : MonoBehaviour
{
    public GameObject objectToSpawn, Left, Up, Right;
    int spawnTimer, spawning;
    int shapePick, score, spawnItem;

    public GameManager game;
    Vector3 left, up, right;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnTimer = 20;
        spawning = 20;
        spawnItem = 1;
        left = new Vector3(-40f, 9.5f);
        up = new Vector3(-37f, 9.5f);
        right = new Vector3(-34f, 9.5f);
    }

    public void Arrows()
    {
        shapePick = Random.Range(1, 4);
        switch(shapePick)
        {
            case 1: objectToSpawn = Left;
                break;
            case 2: objectToSpawn = Up;
                break;
            case 3: objectToSpawn = Right;
                break;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (game.state == "battle")
        {
            spawnTimer--;
            if (spawnTimer <=0)
            {
                Arrows();
                if (objectToSpawn == Left)
                {
                    GameObject newLeft = Instantiate(objectToSpawn, left, Quaternion.identity);
                    newLeft.name = spawnItem.ToString();
                    newLeft.transform.parent = GameObject.Find("PlayerArrowContainer").transform;
                    spawnItem++;
                }
                if (objectToSpawn == Up)
                {
                    GameObject newUp = Instantiate(objectToSpawn, up, Quaternion.identity);
                    newUp.name = spawnItem.ToString();
                    newUp.transform.parent = GameObject.Find("PlayerArrowContainer").transform;
                    spawnItem++;
                }
                if (objectToSpawn == Right)
                {
                    GameObject newRight = Instantiate(objectToSpawn, right, Quaternion.identity);
                    newRight.name = spawnItem.ToString();
                    newRight.transform.parent = GameObject.Find("PlayerArrowContainer").transform;
                    spawnItem++;
                }
                spawnTimer = spawning;
            }
        }
    }
}
