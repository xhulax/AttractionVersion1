using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public float positionX, positionY;
    public float speed;
    public int PositionChoice,DifficultyPick;
    public bool collide;
    public ObjectSpawning Object;
    public SpriteRenderer GodSR, BulletSR;
    Color thisColour;
    public string state;
    public GameObject Player;
    Player play;
    GameManager game;
    Animator Allstates;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        Object = GameObject.Find("Spawning").GetComponent<ObjectSpawning>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player = GameObject.Find("Player");
        Allstates = this.GetComponent<Animator>();
        play = GameObject.Find("Player").GetComponent<Player>();
        GodSR = this.GetComponent<SpriteRenderer>();
        thisColour = this.GetComponent<SpriteRenderer>().color;
        state = "move";
        collide = false;

        speed = Random.Range(0.06f, 0.08f);
        //Difficulty();
        Spawning();
    }

    public void Difficulty()
    {
        DifficultyPick = Random.Range(1, 4);
        switch(DifficultyPick)
        {
            case 1: state = "easy";
                thisColour = Color.black;
                this.GetComponent<SpriteRenderer>().color = thisColour;
                break;
            case 2: state = "medium";
                thisColour = Color.white;
                this.GetComponent<SpriteRenderer>().color = thisColour;
                break;
            case 3: state = "hard";
                thisColour = Color.blue;
                this.GetComponent<SpriteRenderer>().color = thisColour;
                break;
        }
    }
    public void Spawning()
    { 
        PositionChoice = Random.Range(1, 5);
        //Help decide which side the game object will spawn on.
        switch (PositionChoice)
        {
            case 1:
                positionX = Random.Range(-15f, 15f);
                this.transform.position = new Vector3(positionX, 7f, 0);
                break;
            case 2:
                positionY = Random.Range(-9f, 9f);
                this.transform.position = new Vector3(12.5f, positionY, 0);
                break;
            case 3:
                positionX = Random.Range(-15f, 15f);
                this.transform.position = new Vector3(positionX, -7f, 0);
                break;
            case 4:
                positionY = Random.Range(-9f, 9f);
                this.transform.position = new Vector3(-12.5f, positionY, 0);
                break;
        }
    }

    private void OnDestroy()
    {
        Object.GodNum -= 1;
    }

    void Update()
    {
        if (game.state == "play")
        {
            if (state == "attract")
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, 0.1f);
                speed = 0;
            }
            else
            {
                if (PositionChoice == 1)
                {
                    this.transform.position += new Vector3(0, -speed, 0);
                    Allstates.SetFloat("vert", -speed);
                }
                if (PositionChoice == 2)
                {
                    this.transform.position += new Vector3(-speed, 0, 0);
                    Allstates.SetFloat("hori", -speed);
                    GodSR.flipX = true;
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
                    GodSR.flipX = false;
                }
            }
            if (BulletSR != null)
            {
                if (GodSR.bounds.Intersects(BulletSR.bounds))
                {
                    if (GodSR.color != Color.yellow)
                    {
                        GodSR.color = Color.yellow;
                        state = "attract";
                    }
                    if (collide == false)
                    {
                        play.AttractedNum++;
                        Object.GodNum -= 1;
                        collide = true;
                    }
                }
                else
                {
                    if (GodSR.color == Color.yellow)
                    {
                        GodSR.color = Color.green;
                        BulletSR = null;
                    }
                }
            }

            if (this.transform.position.x < -15 || this.transform.position.x > 15) Destroy(gameObject);
            if (this.transform.position.y < -9 || this.transform.position.y > 9) Destroy(gameObject);
        }
        if (game.state == "reset" || game.state == "name") Destroy(this.gameObject);

    }
}
