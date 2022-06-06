using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;



public class Portal : Collidable
{
    public string[] sceneNames;
    
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            coll.transform.position = new Vector3(0, 0, 0);
            //Teleport
            GameManager.instance.SaveState();
            SceneManager.LoadScene(3);
        }
    }
}
