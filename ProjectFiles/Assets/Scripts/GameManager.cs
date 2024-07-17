using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public string state;
    public int GodNum, spawnTimer, spawning, SpeedUp;
    public TextMesh Timer, counter;
    public TextMesh playText,play2Text,HighText,ExitText,Names;
    int timer, frameCount;
    public int timer2, frameRate;
    public GameObject Gods, Enemy, Play, Menu, Exit, Detector,InstructionButt,Play2,Name,Next;
    SpriteRenderer play,play2, menu, exit, detector, instruct,name,next;
    Color playButt, menuButt, exitButt, instructButt,playButt2,nameColour,NextButt;
    public Camera camera;
   public string EnemyState;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        player = GameObject.Find("Player").GetComponent<Player>();
        detector = Detector.GetComponent<SpriteRenderer>();
        play = Play.GetComponent<SpriteRenderer>();
        playButt = Play.GetComponent<SpriteRenderer>().color;
        play2 = Play2.GetComponent<SpriteRenderer>();
        playButt2 = Play2.GetComponent<SpriteRenderer>().color;
        menu = Menu.GetComponent<SpriteRenderer>();
        menuButt = Menu.GetComponent<SpriteRenderer>().color;
        exit = Exit.GetComponent<SpriteRenderer>();
        exitButt = Exit.GetComponent<SpriteRenderer>().color;
        instruct = InstructionButt.GetComponent<SpriteRenderer>();
        instructButt = InstructionButt.GetComponent<SpriteRenderer>().color;
        name = Name.GetComponent<SpriteRenderer>();
        nameColour = Name.GetComponent<SpriteRenderer>().color;
        next = Next.GetComponent<SpriteRenderer>();
        NextButt = Next.GetComponent<SpriteRenderer>().color;
        state = "title";
        timer = 120;
        timer2 = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        //basic colour and text when starting the game
        Names.text = "";
        play2Text.text = "";
        playText.text = "Play";
        HighText.text = "High Score Board";
        ExitText.text = "Exit";
        playButt.a = 1f;
        Play.GetComponent<SpriteRenderer>().color = playButt;
        menuButt.a = 1f;
        menu.GetComponent<SpriteRenderer>().color = menuButt;
        exitButt.a = 1f;
        exit.GetComponent<SpriteRenderer>().color = exitButt;
        playButt2.a = 0f;
        Play2.GetComponent<SpriteRenderer>().color = playButt2;
        nameColour.a = 0f;
        Name.GetComponent<SpriteRenderer>().color = nameColour;
        instructButt.a = 1f;
        InstructionButt.GetComponent<SpriteRenderer>().color = instructButt;


        //code for the tittle screen camera
        if (state == "title")
        {
            camera.transform.position = new Vector3(31, 0, -10);
            play2Text.text = "";
            if (detector.bounds.Intersects(play.bounds))
            {
                playButt.a = 0.5f;
                Play.GetComponent<SpriteRenderer>().color = playButt;
                if (Input.GetKey(KeyCode.Mouse0)) state = "name";
            }
            if (detector.bounds.Intersects(menu.bounds))
            {
                menuButt.a = 0.5f;
                menu.GetComponent<SpriteRenderer>().color = menuButt;
                if (Input.GetKey(KeyCode.Mouse0)) state = "highscore";
            }
            if (detector.bounds.Intersects(exit.bounds))
            {
                exitButt.a = 0.5f;
                exit.GetComponent<SpriteRenderer>().color = exitButt;
                if (Input.GetKey(KeyCode.Mouse0)) Application.Quit();
            }
        }
        //the code to allow the player to put their own input ina  textmesh
        if (state == "name")
        {
            Names.text = "Name: ";
            play2Text.text = "Play";
            playText.text = " ";
            HighText.text = " ";
            ExitText.text = " ";
            nameColour.a = 1f;
            Name.GetComponent<SpriteRenderer>().color = nameColour;
            playButt.a = 0f;
            Play.GetComponent<SpriteRenderer>().color = playButt;
            menuButt.a = 0f;
            menu.GetComponent<SpriteRenderer>().color = menuButt;
            exitButt.a = 0f;
            exit.GetComponent<SpriteRenderer>().color = exitButt;
            playButt2.a = 1f;
            Play2.GetComponent<SpriteRenderer>().color = playButt2; 
            if (detector.bounds.Intersects(play2.bounds))
            {
                playButt2.a = 0.5f;
                Play2.GetComponent<SpriteRenderer>().color = playButt2;
                if (Input.GetKey(KeyCode.Mouse0)) state = "instruction";
            }

        }
        //high score board
        if (state == "highscore") camera.transform.position = new Vector3(0, 21, -10);

        // for the instruction page so the players know what they are doing
        if (state == "instruction")
        {
            camera.transform.position = new Vector3(30, -25, -10);
            if (detector.bounds.Intersects(instruct.bounds))
            {
                instructButt.a = 0.5f;
                InstructionButt.GetComponent<SpriteRenderer>().color = instructButt;
                if (Input.GetKey(KeyCode.Mouse0)) state = "play";
            }
        }

        //when the game manager state is now play
        if (state == "play")
        {
            camera.transform.position = new Vector3(0, 0, -10); //movees camer to this position
            if (timer2 >= 0) // for how long the game will run for.
            {
                frameCount -= 1;
                if (frameCount <= 0)           
                {
                    Timer.text = "Time: " + timer;
                    timer -= 1;
                    frameCount = 60;
                }
            }
            if (timer == 0)state = "gameover";
        }

        //code for when the game manager state is now countDown.
        if (state == "countDown")
        {
            camera.transform.position = new Vector3(-30, 0, -10);
            counter.transform.position = new Vector3(-30, 0);
            if (timer2 >= 0) //countdown to prepare the player to start the battle.
            {
                frameRate -= 1;
                if (frameRate <= 0)
                {
                    counter.text = timer2.ToString();
                    timer2 -= 1;
                    frameRate = 60;
                }
            }
            if (timer2 <= 0)
            {
                counter.text = " ";
                timer2 = 0;
                state = "battle";
                Debug.Log(state);
            }
        }
        //if the player wins the battle scene, hearts will be added
        if (state == "win")
        {
            camera.transform.position = new Vector3(0, 0, -10);
            if (EnemyState == "easy") player.Hearts += 1;
            if (EnemyState == "medium") player.Hearts += 2;
            if (EnemyState == "hard") player.Hearts += 3;
            state = "play";
        }
        //if  the player loses the battle scene, hearts will be taken off
        if (state == "lose")
        {
            camera.transform.position = new Vector3(0, 0, -10);
            if (EnemyState == "easy") player.Hearts -= 1;
            if (EnemyState == "medium") player.Hearts -= 2;
            if (EnemyState == "hard") player.Hearts -= 3;
            state = "play";
        }
       
        //game over
        if (state == "gameover")
        {
            camera.transform.position = new Vector3(0, -25, -10);
            NextButt.a = 1f;
            next.GetComponent<SpriteRenderer>().color = NextButt;
            if (detector.bounds.Intersects(next.bounds))
            {
                NextButt.a = 0.5f;
                next.GetComponent<SpriteRenderer>().color = NextButt;
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    state = "highscore";
                    camera.transform.position = new Vector3(0, 21, -10);
                }
            }
        }
        //manual reset for the game
        if (state == "reset")
        {
            timer = 60;
            timer2 = 3;
            Names.text = "";
            play2Text.text = "";
            playText.text = "Play";
            HighText.text = "High Score";
            ExitText.text = "Exit";
            nameColour.a = 0f;
            Name.GetComponent<SpriteRenderer>().color = nameColour;
            playButt.a = 1f;
            Play.GetComponent<SpriteRenderer>().color = playButt;
            menuButt.a = 1f;
            menu.GetComponent<SpriteRenderer>().color = menuButt;
            exitButt.a = 1f;
            exit.GetComponent<SpriteRenderer>().color = exitButt;
            playButt2.a = 0f;
            Play2.GetComponent<SpriteRenderer>().color = playButt2;
            camera.transform.position = new Vector3(31, 0, -10);
            state = "title";
        }
    }
}
