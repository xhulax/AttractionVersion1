using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    public int GodNum, EnemyNum, GodId, EnemyId,HeartId;
    int spawnTimer, SpeedUp, spawning;
    int EnemySpawnTimer, EnemySpeedUp, EnemySpawning;
    int DifficultyPick, value;
    public string difficulty;
    public GameObject Gods, Enemy1,Enemy2,Enemy3;
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

    // God Character variables and timer
        spawnTimer = 5;
        spawning = 30;
        SpeedUp = 360;
        GodNum = 1;
        GodId = 1;

        //Enemy variables and timer
        EnemyId = 1;
        EnemyNum = 1;
        EnemySpawning = 30;
        EnemySpawnTimer = 30;
        EnemySpeedUp = 360;
    }

    public void Difficulty()
    {
        DifficultyPick = Random.Range(1, 4);
        switch (DifficultyPick)
        {
            case 1:
                difficulty = "easy";
                break;
            case 2:
                difficulty = "medium";
                break;
            case 3:
                difficulty = "hard";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "reset" || game.state == "name")
        {
            spawnTimer = 5;
            spawning = 30;
            SpeedUp = 360;
            GodNum = 1;
            GodId = 1;

            //Enemy variables and timer
            EnemyId = 1;
            EnemyNum = 1;
            EnemySpawning = 30;
            EnemySpawnTimer = 30;
            EnemySpeedUp = 360;
        }

        if (game.state == "play")
        {
            if (GodNum <= 0) GodNum = 0;
            spawnTimer--;
            //The spawning and creation of the god characters
            if (GodNum != 4)
            {
                if (spawnTimer <= 0)
                {
                    GameObject newGod = Instantiate(Gods, transform.position, Quaternion.identity);
                    newGod.name = GodId.ToString();
                    newGod.transform.parent = GameObject.Find("GodContainer").GetComponent<Transform>();
                    GodNum ++;
                    GodId++;
                    spawnTimer = 30;
                }
            }

            //the spawning and creation of the enemies
            EnemySpawnTimer--;
            if (EnemyNum <= 0) EnemyNum = 0;
            if (EnemyNum != 5)
            {
                if (EnemySpawnTimer <= 0)
                {
                    Difficulty();
                    if (difficulty == "easy")
                    {
                        GameObject newEnemy = Instantiate(Enemy1, transform.position, Quaternion.identity);
                        newEnemy.name = EnemyId.ToString();
                        newEnemy.GetComponent<Enemy>().difficulty = difficulty;
                        newEnemy.transform.parent = GameObject.Find("EnemyContainer").GetComponent<Transform>();
                        EnemyNum++;
                        EnemyId++;
                        EnemySpawnTimer = 30;
                    }
                    if (difficulty == "medium")
                    {
                        GameObject newEnemy = Instantiate(Enemy2, transform.position, Quaternion.identity);
                        newEnemy.GetComponent<Enemy>().difficulty = difficulty;
                        newEnemy.name = EnemyId.ToString();
                        newEnemy.transform.parent = GameObject.Find("EnemyContainer").GetComponent<Transform>();
                        EnemyNum++;
                        EnemyId++;
                        EnemySpawnTimer = 30;
                    }
                    if (difficulty == "hard")
                    {
                        GameObject newEnemy = Instantiate(Enemy3, transform.position, Quaternion.identity);
                        newEnemy.name = EnemyId.ToString();
                        newEnemy.GetComponent<Enemy>().difficulty = difficulty;
                        newEnemy.transform.parent = GameObject.Find("EnemyContainer").GetComponent<Transform>();
                        EnemyNum++;
                        EnemyId++;
                        EnemySpawnTimer = 30;
                    }
                }
            }
        }
    }
}
