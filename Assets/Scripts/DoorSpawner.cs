using System;
using System.Collections;
using System.Collections.Generic;
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
        
        Debug.Log(gameObject.transform.parent.parent.tag);
        
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

        if (roomString.Equals("secret")) 
        {
            
            if (other.CompareTag("DoorT"))
            {
                var door = Instantiate(temps.walls[0], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[4], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else if(other.CompareTag("DoorR"))
            {
                var door = Instantiate(temps.walls[1], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[5], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else if(other.CompareTag("DoorB"))
            {
                var door = Instantiate(temps.walls[2], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[4], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else if(other.CompareTag("DoorL"))
            {
                var door = Instantiate(temps.walls[3], transform.position, Quaternion.identity);
                door.transform.parent = gameObject.transform.parent;
                Instantiate(temps.walls[5], transform.position, Quaternion.identity);
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
        
        
    }
}
