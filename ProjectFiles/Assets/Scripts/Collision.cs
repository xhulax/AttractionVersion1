using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    GameObject Bullet;
    SpriteRenderer ThisSR;
    Transform RefToBullet, RefToGod;
    public int ID = 1;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;

        ThisSR = this.GetComponent<SpriteRenderer>();
        RefToBullet = GameObject.Find("BulletContainer").transform;
        RefToGod = GameObject.Find("GodContainer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisSR.color == Color.magenta) ThisSR.color = Color.cyan;
        while (ID < RefToGod.childCount)
        {
            if (ThisSR.bounds.Intersects(RefToGod.GetChild(ID).GetComponent<SpriteRenderer>().bounds))
            {                
                RefToGod.GetChild(ID).GetComponent<God>().BulletSR = ThisSR;
                ThisSR.color = Color.magenta;
            }
            ID++;
        }
        ID = 0;
    }
}
