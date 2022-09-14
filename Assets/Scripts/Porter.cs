using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Porter : Collidable
{
    public string[] sceneNames;
    
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Teleport
            GameManager.instance.SaveState();
            coll.transform.position = new Vector3(0, 0, 0);
            Debug.Log("Teleported...");
        }
    }
}
