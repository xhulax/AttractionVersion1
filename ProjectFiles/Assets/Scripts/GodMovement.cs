using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMovement : MonoBehaviour
{
    public float positionX, positionY;
    public float speed;
    public int PositionChoice;
    GameManager game;
    Animator Allstates;
    SpriteRenderer god;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        Allstates = this.GetComponent<Animator>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        god = this.GetComponent<SpriteRenderer>();
        PositionChoice = Random.Range(1, 5);
        speed = Random.Range(0.05f, 0.15f);
        Spawning();
    }

    public void Spawning()
    {
        //Help decide which side the game object will spawn on.
        switch (PositionChoice)
        {
            case 1:
                positionX = Random.Range(-12f, 12f);
                this.transform.position = new Vector3(positionX, 7f, 0);
                break;
            case 2:
                positionY = Random.Range(-6f, 6f);
                this.transform.position = new Vector3(12.5f, positionY, 0);
                break;
            case 3:
                positionX = Random.Range(-12f, 12f);
                this.transform.position = new Vector3(positionX, -7f, 0);
                break;
            case 4:
                positionY = Random.Range(-6f, 6f);
                this.transform.position = new Vector3(-12.5f, positionY, 0);
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "play")
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
                god.flipX = true;
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
                god.flipX = false;
            }
            if (this.transform.position.x < -15 || this.transform.position.x > 15) Destroy(gameObject);
            if (this.transform.position.y < -9 || this.transform.position.y > 9) Destroy(gameObject);
        }
    }
}
