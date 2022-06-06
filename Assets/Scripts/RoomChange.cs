using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoomChange : Collidable
{
    public int direction;



    protected override void OnCollide(Collider2D coll)
    {
        GameObject cam = GameObject.Find("Main Camera");
        if (coll.name == "Player")
        {
            GameManager.instance.SaveState();
            
            if (direction == 1) {
                coll.transform.position -= new Vector3(0, 0.17f, 0);
                CameraMotor.newPos -= new Vector3(0, 1.920012f/4, 0);
            }else if (direction == 2){
                coll.transform.position -= new Vector3(0.17f, 0, 0);
                CameraMotor.newPos -= new Vector3(2.880018f/4, 0, 0);
            }else if (direction == 3) {
                coll.transform.position += new Vector3(0, 0.17f, 0);
                CameraMotor.newPos += new Vector3(0, 1.920012f/4, 0);
            }else if (direction == 4) {
                coll.transform.position += new Vector3(0.17f, 0, 0);
                CameraMotor.newPos +=  new Vector3(2.880018f/4, 0, 0);
            }
        }
    }
}
