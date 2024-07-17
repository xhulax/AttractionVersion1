using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform playerBar, enemyBar;
    public string state;
    public int speedChoice, timer, frameRate;
    public float speed;
    Vector3 win, lose;
    public GameManager game;
    public Player play;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        state = "battle";
        timer = 1;
        frameRate = 30;
        play = GameObject.Find("Player").GetComponent<Player>();
        speedChoice = Random.Range(1, 4);
        EnemySpeed();
    }

    public void EnemySpeed()
    {
        switch(speedChoice)
        {
            case 1: speed = 0.1f;
                break;
            case 2: speed = 0.2f;
                break;
            case 3: speed = 0.3f;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (game.state == "battle" && state == "battle")
        {

            if (playerBar.transform.localScale.x >= 2f)
            {
                enemyBar.transform.localScale = new Vector3(0f, 1);
                game.state = "win";
                play.state = "winner";

            }
            if (playerBar.transform.localScale.x <= 0f)
            {
                enemyBar.transform.localScale = new Vector3(2f, 1);
                game.state = "lose";
                play.state = "loser";
                
            }
        }
        if (game.state == "play")
        {
            game.timer2 = 3;
            state = "battle";
            playerBar.transform.localScale = new Vector3(1f, 1);
            enemyBar.transform.localScale = new Vector3(1f, 1);
        }
    }
}
