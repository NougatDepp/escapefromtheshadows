using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DoorSpawner : MonoBehaviour
{
    private DoorTemplates temps;
    private int rand;
        
    private void Start()
    {
        //temps = GameObject.FindGameObjectWithTag("Doors").GetComponent<DoorTemplates>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        temps = GameObject.FindGameObjectWithTag("Doors").GetComponent<DoorTemplates>();

        if (!other.gameObject.CompareTag("DoorT")&&!other.gameObject.CompareTag("DoorR")&&!other.gameObject.CompareTag("DoorB")&&!other.gameObject.CompareTag("DoorL")) return;

        String roomString;

        if (gameObject.transform.parent.parent.CompareTag("SecretRoom")||other.gameObject.transform.parent.parent.CompareTag("SecretRoom"))
        {
            roomString = "secret";
        }
        else if(gameObject.transform.parent.parent.CompareTag("BossRoom")||other.gameObject.transform.parent.parent.CompareTag("BossRoom"))
        {
            roomString = "boss";
        }
        else if (gameObject.transform.parent.parent.CompareTag("TreasureRoom")||other.gameObject.transform.parent.parent.CompareTag("TreasureRoom"))
        {
            roomString = "treasure";
        }
        else
        {
            roomString = "normal";
        }

        if (other.CompareTag("DoorB")) gameObject.transform.parent.parent.name = gameObject.transform.parent.parent.name +"T";
        if (other.CompareTag("DoorL")) gameObject.transform.parent.parent.name = gameObject.transform.parent.parent.name +"R";
        if (other.CompareTag("DoorT")) gameObject.transform.parent.parent.name = gameObject.transform.parent.parent.name +"B";
        if (other.CompareTag("DoorR")) gameObject.transform.parent.parent.name = gameObject.transform.parent.parent.name +"L";
        
        
        
        
        
        if (roomString.Equals("secret")) 
        {
            
            if (other.CompareTag("DoorT"))
            {
                var door = Instantiate(temps.specialDoors[4], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else if(other.CompareTag("DoorR"))
            {
                var door = Instantiate(temps.specialDoors[5], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[1], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else if(other.CompareTag("DoorB"))
            {
                var door = Instantiate(temps.specialDoors[6], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else if(other.CompareTag("DoorL"))
            {
                var door = Instantiate(temps.specialDoors[7], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[1], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
        else if(roomString.Equals("normal"))
        {
            if (other.CompareTag("DoorT"))
            {
                var door = Instantiate(temps.normalDoors[0], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorR"))
            {
                var door = Instantiate(temps.normalDoors[1], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorB"))
            {
                var door = Instantiate(temps.normalDoors[2], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorL"))
            {
                var door = Instantiate(temps.normalDoors[3], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }
        }
        else if(roomString.Equals("treasure"))
        {
            if (other.CompareTag("DoorT"))
            {
                var door = Instantiate(temps.specialDoors[8], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorR"))
            {
                var door = Instantiate(temps.specialDoors[9], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorB"))
            {
                var door = Instantiate(temps.specialDoors[10], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorL"))
            {
                var door = Instantiate(temps.specialDoors[11], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }
        }
        else if(roomString.Equals("boss"))
        {
            if (other.CompareTag("DoorT"))
            {
                var door = Instantiate(temps.specialDoors[0], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorR"))
            {
                var door = Instantiate(temps.specialDoors[1], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorB"))
            {
                var door = Instantiate(temps.specialDoors[2], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }else if(other.CompareTag("DoorL"))
            {
                var door = Instantiate(temps.specialDoors[3], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Destroy(gameObject);
            }
        }
    }
}
