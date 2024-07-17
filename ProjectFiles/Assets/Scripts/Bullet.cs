using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int ID = 1;
    public GameObject detector;
    Transform RefToEnemy;
    Vector2 currentDestination;
    public SpriteRenderer BulletSR, GodSR;
    GameManager game;
    bool shoot;
    float speed = 0.3f;
    int timer, frameCount;
    public string state;
    public Player play;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        timer = 1;
        frameCount = 60;
        shoot = false;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        BulletSR = this.GetComponent<SpriteRenderer>();
        detector = GameObject.Find("Detector");
        currentDestination = (detector.transform.position - transform.position).normalized * speed;
        state = "idle";
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == "play")
        {

            if (Input.GetKey(KeyCode.Mouse0)) state = "shoot";
            if (state == "shoot")
            {
                this.transform.position += new Vector3(currentDestination.x, currentDestination.y);
                if (this.transform.position.x < -15 || this.transform.position.x > 15) Destroy(gameObject);
                if (this.transform.position.y < -9 || this.transform.position.y > 9) Destroy(gameObject);
            }

        }
        if (game.state == "reset" || game.state == "name") Destroy(this.gameObject);

    }
}
