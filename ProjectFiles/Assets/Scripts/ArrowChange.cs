using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChange : MonoBehaviour
{
    public int score;
    public string state,enemyState;
    public GameObject left, up, right;
    Color32 LeftColour, UpColour, RightColour;
    public TextMesh announce;
    GameManager game;
    ArrowMovement arrow;
    public HealthBar health;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        LeftColour = left.GetComponent<SpriteRenderer>().color;
        UpColour = up.GetComponent< SpriteRenderer>().color;
        RightColour = right.GetComponent<SpriteRenderer>().color;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "battle")
        {
            LeftColour.a = 125;
            left.GetComponent<SpriteRenderer>().color = LeftColour;

            UpColour.a = 125;
            up.GetComponent<SpriteRenderer>().color = UpColour;

            RightColour.a = 125;
            right.GetComponent<SpriteRenderer>().color = RightColour;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                LeftColour.a = 255;
                left.GetComponent<SpriteRenderer>().color = LeftColour;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                UpColour.a = 255;
                up.GetComponent<SpriteRenderer>().color = UpColour;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                RightColour.a = 255;
                right.GetComponent<SpriteRenderer>().color = RightColour;
            }

            if (state == "early")
            {
                health.playerBar.transform.localScale -= new Vector3(0.05f, 0);
                health.enemyBar.transform.localScale += new Vector3(0.05f, 0);
                Debug.Log(state);
                state = "play";
            }
            if (state == "ok")
            {
                health.playerBar.transform.localScale += new Vector3(0.05f, 0);
                health.enemyBar.transform.localScale -= new Vector3(0.05f, 0);
                Debug.Log(state);
                state = "play";
            }
            if (state == "good")
            {
                health.playerBar.transform.localScale += new Vector3(0.075f, 0);
                health.enemyBar.transform.localScale -= new Vector3(0.075f, 0);
                Debug.Log(state);
                state = "play";
            }
            if (state == "perfect")
            {
                health.playerBar.transform.localScale += new Vector3(0.1f, 0);
                health.enemyBar.transform.localScale -= new Vector3(0.1f, 0);
                Debug.Log(state);
                state = "play";
            }

            if (enemyState == "ok")
            {
                health.playerBar.transform.localScale -= new Vector3(0.05f, 0);
                health.enemyBar.transform.localScale += new Vector3(0.05f, 0);
                Debug.Log(state);
                enemyState = "play";
            }
            if (enemyState == "good")
            {
                health.playerBar.transform.localScale -= new Vector3(0.075f, 0);
                health.enemyBar.transform.localScale += new Vector3(0.075f, 0);
                Debug.Log(state);
                enemyState = "play";
            }
            if (enemyState == "perfect")
            {
                health.playerBar.transform.localScale -= new Vector3(0.1f, 0);
                health.enemyBar.transform.localScale += new Vector3(0.1f, 0);
                Debug.Log(state);
                enemyState = "play";
            }
        }
    }
}
