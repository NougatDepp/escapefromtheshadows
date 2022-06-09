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
                CameraMotor.newPos -= new Vector3(0, 1.920012f, 0);
                new WaitForSecondsRealtime(1);
                coll.transform.position -= new Vector3(0, 0.7f, 0);
            }else if (direction == 2){
                CameraMotor.newPos -= new Vector3(2.880018f, 0, 0);
                new WaitForSecondsRealtime(1);
                coll.transform.position -= new Vector3(0.7f, 0, 0);
            }else if (direction == 3) {
                CameraMotor.newPos += new Vector3(0, 1.920012f, 0);
                new WaitForSecondsRealtime(1);
                coll.transform.position += new Vector3(0, 0.7f, 0);
            }else if (direction == 4) {
                CameraMotor.newPos +=  new Vector3(2.880018f, 0, 0);
                new WaitForSecondsRealtime(1);
                coll.transform.position += new Vector3(0.7f, 0, 0);
            }
        }
    }
}
