using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager game;
    public GameObject detector, bullet;
    SpriteRenderer player,Enemy;
    Animator Allstates;
    God godCharacter;
    Bullet bull;
    Transform RefToEnemy;
    public ObjectSpawning objectSpawn;
    public TextMesh hearts,gameOverHearts;
    public EnemyArrowMovement enemyArrow;
    public int AttractedNum;
    public int Hearts, BullNum, ID;
    public string enemyDifficulty, state;
    float speed;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectSpawn = GameObject.Find("Spawning").GetComponent<ObjectSpawning>();
        RefToEnemy = GameObject.Find("EnemyContainer").transform;
        player = this.GetComponent<SpriteRenderer>();
        Allstates = this.GetComponent<Animator>();
        Hearts = 15;
        BullNum = 1;
        canMove = true;
        speed = 0.09f;
        ID = 1;
        AttractedNum = 0;
        state = "play";
    }

    // Update is called once per frame
    void Update()
    {
        Allstates.SetFloat("hori", Input.GetAxis("Horizontal"));
        Allstates.SetFloat("vert", Input.GetAxis("Vertical"));

        hearts.text = " Hearts: " + Hearts;
        detector.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        if (game.state == "play")
        {
            if (this.transform.position.x > -14f)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += new Vector3(-speed, 0, 0);
                    player.flipX = true;
                }
            }
            if (this.transform.position.x < 14f)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.position += new Vector3(speed, 0, 0);
                    player.flipX = false;
                }
            }
            if (this.transform.position.y < 8f) if (Input.GetKey(KeyCode.W)) this.transform.position += new Vector3(0, speed, 0);
            if (this.transform.position.y > -8f) if (Input.GetKey(KeyCode.S)) this.transform.position += new Vector3(0, -speed, 0);

            if (Input.GetKeyDown(KeyCode.Mouse0) && Hearts > 0)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.name = BullNum.ToString();
                newBullet.transform.parent = GameObject.Find("BulletContainer").transform;
                BullNum++;
                Hearts--;
            }

            while (ID < RefToEnemy.childCount)
            {
                if (player.bounds.Intersects(RefToEnemy.GetChild(ID).GetComponent<SpriteRenderer>().bounds))
                {
                    RefToEnemy.GetChild(ID).GetComponent<Enemy>().player = player;
                    enemyArrow.DifficultyState = RefToEnemy.GetChild(ID).GetComponent<Enemy>().difficulty;
                }

                ID++;
            }
            ID = 0;
            if (Hearts <= 0)
            {
                Hearts = 0;
                game.state = "gameover";
            }
        }
        if (game.state == "gameover") gameOverHearts.text = "You attracted: " + AttractedNum.ToString();
        if (game.state == "reset" || game.state == "title" || game.state == "name")
        {
            Hearts = 15;
            BullNum = 1;
            canMove = true;
            speed = 0.07f;
            ID = 1;
            AttractedNum = 0;
            this.transform.position = new Vector3(0, 0);
        }
    }
}

