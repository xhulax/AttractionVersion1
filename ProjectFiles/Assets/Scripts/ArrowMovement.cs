using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speeed = 0.1f;
    public string state = "move";
    bool collision;
    SpriteRenderer ThisObject;
    SpriteRenderer OkLeft, GoodLeft, PerfLeft;
    SpriteRenderer OkUp, GoodUp, PerfUp;
    SpriteRenderer OkRight, GoodRight, PerfRight;
    public GameManager game;
    ArrowChange arrow;
    public TextMesh announce;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        arrow = GameObject.Find("PlayerArrows").GetComponent<ArrowChange>();
        announce = GameObject.Find("Announcer").GetComponent<TextMesh>();
        ThisObject = this.GetComponent<SpriteRenderer>();
        OkLeft = GameObject.Find("OkayLeft").GetComponent<SpriteRenderer>();
        GoodLeft = GameObject.Find("GoodLeft").GetComponent<SpriteRenderer>();
        PerfLeft = GameObject.Find("PerfectLeft").GetComponent<SpriteRenderer>();

        OkUp = GameObject.Find("OkayUp").GetComponent<SpriteRenderer>();
        GoodUp = GameObject.Find("GoodUp").GetComponent<SpriteRenderer>();
        PerfUp = GameObject.Find("PerfectUp").GetComponent<SpriteRenderer>();

        OkRight = GameObject.Find("OkayRight").GetComponent<SpriteRenderer>();
        GoodRight = GameObject.Find("GoodRight").GetComponent<SpriteRenderer>();
        PerfRight = GameObject.Find("PerfectRight").GetComponent<SpriteRenderer>();
        collision = false;
    }

    private void OnDestroy()
    {
        announce.text = state;
        arrow.state = state;
        if (state == "ok") arrow.score += 10;
        if (state == "good") arrow.score += 20;
        if (state == "perfect") arrow.score += 30;
    }
    // Update is called once per frame
    void Update()
    {
        state = arrow.state;
        if (game.state == "battle")
        {
            this.transform.position -= new Vector3(0, speeed, 0);
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {

                if (ThisObject.bounds.Intersects(OkLeft.bounds))
                {
                    state = "ok";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
                if (ThisObject.bounds.Intersects(GoodLeft.bounds))
                {
                    state = "good";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
                if (ThisObject.bounds.Intersects(PerfLeft.bounds))
                {
                    state = "perfect";
                    collision = !collision;
                    Destroy(this.gameObject);
                }  
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (ThisObject.bounds.Intersects(OkUp.bounds))
                {
                    state = "ok";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
                if (ThisObject.bounds.Intersects(GoodUp.bounds))
                {
                    state = "good";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
                if (ThisObject.bounds.Intersects(PerfUp.bounds))
                {
                    state = "perfect";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (ThisObject.bounds.Intersects(OkRight.bounds))
                {
                    state = "ok";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
                if (ThisObject.bounds.Intersects(GoodRight.bounds))
                {
                    state = "good";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
                if (ThisObject.bounds.Intersects(PerfRight.bounds))
                {
                    state = "perfect";
                    collision = !collision;
                    Destroy(this.gameObject);
                }
            }
            else if (this.transform.position.y <= -9)
            {
                state = "miss";
                collision = !collision;
                Destroy(this.gameObject);
            }
        }
        if (game.state != "battle") Destroy(this.gameObject);
    }
}
