using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn",1f);
        
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.topDoorRooms.Length - 1);
                Instantiate(templates.topDoorRooms[rand],transform.position,templates.topDoorRooms[rand].transform.rotation);
            }else if (openingDirection == 4) {
                rand = Random.Range(0, templates.rightDoorRooms.Length - 1);
                Instantiate(templates.rightDoorRooms[rand],transform.position,templates.rightDoorRooms[rand].transform.rotation);
            }else if (openingDirection == 1) {
                rand = Random.Range(0, templates.bottomDoorRooms.Length - 1);
                Instantiate(templates.bottomDoorRooms[rand],transform.position,templates.bottomDoorRooms[rand].transform.rotation);
            }else if (openingDirection == 2) {
                rand = Random.Range(0, templates.leftDoorRooms.Length - 1);
                Instantiate(templates.leftDoorRooms[rand],transform.position,templates.leftDoorRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(this.gameObject);
        }
    }
}
