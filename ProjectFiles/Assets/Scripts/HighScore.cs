using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameObject Menu,Reset, Detector;
    SpriteRenderer menu,reset,detector;
    Color menuButt, Resetbutt;
    public TextMesh Name1, Name2, Name3, Name4, Name5;
    public TextMesh score0, score1, score2, score3, score4;
    public int Score0, Score1, Score2, Score3, Score4, newScore;
    public string name1, name2, name3, name4, name5, newName;
    public bool displayScore, checkScore;
    Player play;
    GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        displayScore = true;
        play = GameObject.Find("Player").GetComponent<Player>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        detector = Detector.GetComponent<SpriteRenderer>();
        menu = Menu.GetComponent<SpriteRenderer>();
        menuButt = Menu.GetComponent<SpriteRenderer>().color;
        reset = Reset.GetComponent<SpriteRenderer>();
        Resetbutt = Reset.GetComponent<SpriteRenderer>().color;
        checkScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "highscore")
        {
            if (checkScore == true)
            {
                newScore = play.AttractedNum;
                if (newScore >= Score0)
                {
                    Score4 = Score3;
                    name5 = name4;
                    Score3 = Score2;
                    name4 = name3;
                    Score2 = Score1;
                    name3 = name2;
                    Score1 = Score0;
                    name2 = name1;
                    Score0 = newScore;
                    name1 = newName;
                    newScore = 0;
                }
                else if (newScore >= Score1)
                {
                    Score4 = Score3;
                    name5 = name4;
                    Score3 = Score2;
                    name4 = name3;
                    Score2 = Score1;
                    name3 = name2;
                    Score1 = newScore;
                    name2 = newName;
                    newScore = 0;
                }
                else if (newScore >= Score2)
                {
                    Score4 = Score3;
                    name5 = name4;
                    Score3 = Score2;
                    name4 = name3;
                    Score2 = newScore;
                    name3 = newName;
                    newScore = 0;
                }

                else if (newScore >= Score3)
                {
                    Score4 = Score3;
                    name5 = name4;
                    Score3 = newScore;
                    name4 = newName;
                    newScore = 0;
                }
                else if (newScore >= Score4)
                {
                    Score4 = newScore;
                    name5 = newName;
                    newScore = 0;
                }
                checkScore = false;
            }
            Name1.text = name1;
            Name2.text = name2;
            Name3.text = name3;
            Name4.text = name4;
            Name5.text = name5;
            score0.text = Score0.ToString();
            score1.text = Score1.ToString();
            score2.text = Score2.ToString();
            score3.text = Score3.ToString();
            score4.text = Score4.ToString();

            menuButt.a = 1f;
            Menu.GetComponent<SpriteRenderer>().color = menuButt;
            Resetbutt.a = 1f;
            Reset.GetComponent<SpriteRenderer>().color = Resetbutt;
            if (detector.bounds.Intersects(reset.bounds))
            {
                Resetbutt.a = 0.5f;
                Reset.GetComponent<SpriteRenderer>().color = Resetbutt;
                if (Input.GetKey(KeyCode.Mouse0)) game.state = "reset";
            }
            if (detector.bounds.Intersects(menu.bounds))
            {
                menuButt.a = 0.5f;
                Menu.GetComponent<SpriteRenderer>().color = menuButt;
                if (Input.GetKey(KeyCode.Mouse0)) game.state = "title";
            }
        }
        if (game.state == "reset" || game.state == "name") checkScore = true; 
    }
}
