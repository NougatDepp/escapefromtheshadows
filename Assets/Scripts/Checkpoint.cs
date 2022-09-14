using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Collidable
{

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Save Location
            GameManager.instance.SaveState();
            GameManager.instance.Checkpoint = GameObject.Find("Player").transform.position;
        }
    }
}
