using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float positionX, positionY;
    public float speed;
    public int PositionChoice, DifficultyPick, value;
    public string difficulty;

    Animator Allstates;
    GameManager game;
    public GameObject Player, Bullet;
    public SpriteRenderer player,enemy,bullet;
    Color enemyColour;
    ObjectSpawning objectSpawn;
    Player play;
    public EnemyArrowMovement enemyMoveLeft, enemyMoveUp, enemyMoveRight;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Allstates = this.GetComponent<Animator>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player = GameObject.Find("Player");
        play = GameObject.Find("Player").GetComponent<Player>();
        objectSpawn = GameObject.Find("Spawning").GetComponent<ObjectSpawning>();
        player = Player.GetComponent<SpriteRenderer>();
        enemy = this.GetComponent<SpriteRenderer>();
        enemyColour = this.GetComponent<SpriteRenderer>().color;
        speed = Random.Range(0.06f, 0.08f);
        //Difficulty();
        Spawning();
    }

    public void Spawning()
    {
        PositionChoice = Random.Range(1, 5);
        //Help decide which side the game object will spawn on.
        switch (PositionChoice)
        {
            case 1:
                positionX = Random.Range(-14f, 14f);
                this.transform.position = new Vector3(positionX, 7f);
                break;
            case 2:
                positionY = Random.Range(-8f, 8f);
                this.transform.position = new Vector3(12.5f, positionY);
                break;
            case 3:
                positionX = Random.Range(-14f, 14f);
                this.transform.position = new Vector3(positionX, -7f);
                break;
            case 4:
                positionY = Random.Range(-8f, 8f);
                this.transform.position = new Vector3(-12.5f, positionY);
                break;
        }
    }

    private void OnDestroy()
    {
        objectSpawn.EnemyNum--;
    }
    // Update is called once per frame
    void Update()
    {
           //Allstates.SetFloat("hori", Input.GetAxis("Horizontal"));
           //Allstates.SetFloat("vert", Input.GetAxis("Vertical"));
        if (game.state == "play")
        {        

            if (PositionChoice == 1)
            {
                this.transform.position += new Vector3(0, -speed, 0);
                Allstates.SetFloat("vert",-speed); 
            }
            if (PositionChoice == 2)
            {
                this.transform.position += new Vector3(-speed, 0, 0);
               Allstates.SetFloat("hori", -speed);
                enemy.flipX = true;
            }
            if (PositionChoice == 3)
            {
                this.transform.position += new Vector3(0, speed, 0);
                Allstates.SetFloat("vert", speed);
            }
            if (PositionChoice == 4)
            {
                this.transform.position += new Vector3(speed, 0, 0);
                Allstates.SetFloat("hori", speed);
                enemy.flipX = false;
            }

            if (player != null)
            {
                //difficulty = objectSpawn.difficulty;
                if (enemy.bounds.Intersects(player.bounds) && enemyColour.a == 1f)
                {
                    enemyMoveLeft.DifficultyState = difficulty;
                    enemyMoveUp.DifficultyState = difficulty;
                    enemyMoveRight.DifficultyState = difficulty;
                    game.state = "countDown";
                }

            }
        }
        if (game.state == "win")
        {
            enemyColour.a = 0.5f;
            enemy.GetComponent<SpriteRenderer>().color = enemyColour;
        }
        if (game.state == "lose")
        {
            enemyColour.a = 0.5f;
            enemy.GetComponent<SpriteRenderer>().color = enemyColour;
        }

        if (this.transform.position.x < -15 || this.transform.position.x > 15) Destroy(gameObject);
        if (this.transform.position.y < -9 || this.transform.position.y > 9) Destroy(gameObject);
        if (game.state == "reset" || game.state == "name") Destroy(this.gameObject);
    }
}
