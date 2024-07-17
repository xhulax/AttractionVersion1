using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour
{
    public TextMesh NameText;
    public string newCharacter, displayName;
    int timer, LetterID;
    bool flashOn;
    public GameManager game;
    public HighScore highscore;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        highscore = GameObject.Find("HighScoreBoard").GetComponent<HighScore>();
        newCharacter = "";
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "name")
        {
            timer++;
            if (timer >= 20)
            {
                if (flashOn) NameText.text = displayName + "_";
                if (!flashOn) NameText.text = displayName + newCharacter;
                flashOn = !flashOn;
                timer = 0;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                newCharacter = "A";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                newCharacter = "B";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                newCharacter = "C";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                newCharacter = "D";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                newCharacter = "E";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                newCharacter = "F";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                newCharacter = "G";
                displayName += newCharacter;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                newCharacter = "H";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                newCharacter = "I";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                newCharacter = "J";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                newCharacter = "K";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                newCharacter = "L";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                newCharacter = "M";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                newCharacter = "N";
                displayName += newCharacter;
   
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                newCharacter = "O";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                newCharacter = "P";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                newCharacter = "Q";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                newCharacter = "R";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                newCharacter = "S";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                newCharacter = "T";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                newCharacter = "U";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                newCharacter = "V";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                newCharacter = "W";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                newCharacter = "X";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                newCharacter = "Y";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                newCharacter = "Z";
                displayName += newCharacter;

            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                displayName = "";
                newCharacter = "";
            }
        }
        if (displayName != "" && game.state == "instruction") highscore.newName = displayName;
        if (game.state != "name")
        {
            NameText.text = "";
            displayName = "";
            newCharacter = "";
        }
    }
}
