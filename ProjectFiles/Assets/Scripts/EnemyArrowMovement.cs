using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowMovement : MonoBehaviour
{
    public float speeed = 0.1f;
    public string state, DifficultyState;
    SpriteRenderer ThisObject;
    SpriteRenderer OkLeft, GoodLeft, PerfLeft;
    SpriteRenderer OkUp, GoodUp, PerfUp;
    SpriteRenderer OkRight, GoodRight, PerfRight;
    Color thisColour;
    public GameManager game;
    ArrowChange arrow;
    public Enemy enemy;
    public int CollisionCheck, CollisionValue,collide;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        state = "move";
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        arrow = GameObject.Find("PlayerArrows").GetComponent<ArrowChange>();
        ThisObject = this.GetComponent<SpriteRenderer>();
        thisColour = this.GetComponent<SpriteRenderer>().color;
        OkLeft = GameObject.Find("EOkayLeft").GetComponent<SpriteRenderer>();
        GoodLeft = GameObject.Find("EGoodLeft").GetComponent<SpriteRenderer>();
        PerfLeft = GameObject.Find("EPerfectLeft").GetComponent<SpriteRenderer>();

        OkUp = GameObject.Find("EOkayUp").GetComponent<SpriteRenderer>();
        GoodUp = GameObject.Find("EGoodUp").GetComponent<SpriteRenderer>();
        PerfUp = GameObject.Find("EPerfectUp").GetComponent<SpriteRenderer>();

        OkRight = GameObject.Find("EOkayRight").GetComponent<SpriteRenderer>();
        GoodRight = GameObject.Find("EGoodRight").GetComponent<SpriteRenderer>();
        PerfRight = GameObject.Find("EPerfectRight").GetComponent<SpriteRenderer>();
        Difficulty();
    }

    private void OnDestroy()
    {
        CollisionCheck = Random.Range(1, 101);
        arrow.enemyState = state;
        if (state == "ok") arrow.score += 10;
        if (state == "good") arrow.score += 20;
        if (state == "perfect") arrow.score += 30;
    }

    public void Difficulty()
    {
        switch(DifficultyState)
        {
            case "easy": CollisionValue = 30;
                break;
            case "medium": CollisionValue = 60;
                break;
            case "hard": CollisionValue = 90;
                break;
        }
        CollisionCheck = Random.Range(1, 101);
    }
    // Update is called once per frame
    void Update()
    {
        collide = Random.Range(1, 4);
        //game.difficulty = DifficultyState;
        if (game.state == "battle")
        {
            game.EnemyState = DifficultyState;
            this.transform.position -= new Vector3(0, speeed, 0);
            if (CollisionCheck <= CollisionValue)
            {
                if (ThisObject.bounds.Intersects(OkLeft.bounds))
                {
                    state = "ok";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(GoodLeft.bounds))
                {
                    state = "good";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(PerfLeft.bounds))
                {
                    state = "perfetc";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(OkUp.bounds))
                {
                    state = "ok";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(GoodUp.bounds))
                {
                    state = "good";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(PerfUp.bounds))
                {
                    state = "perfect";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(OkRight.bounds))
                {
                    state = "ok";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(GoodRight.bounds))
                {
                    state = "good";
                    Destroy(this.gameObject);
                }
                else if (ThisObject.bounds.Intersects(PerfRight.bounds))
                {
                    state = "perfect";
                    Destroy(this.gameObject);
                }
            }
            if (this.transform.position.y < -10 || this.transform.position.y > 10) Destroy(gameObject);
        }
        if (game.state != "battle") Destroy(this.gameObject);
    }
}
