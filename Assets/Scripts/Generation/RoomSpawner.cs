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
        Invoke("Spawn",0.1f);
        
    }

    private void Spawn2()
    {
        if (spawned == false)
        {
            if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.topDoorRooms.Length - 1);
                var room = Instantiate(templates.topDoorRooms[rand],transform.position,Quaternion.identity);
                room.transform.parent = gameObject.transform.parent;
            }else if (openingDirection == 4) {
                rand = Random.Range(0, templates.rightDoorRooms.Length - 1);
                var room = Instantiate(templates.rightDoorRooms[rand],transform.position,Quaternion.identity);
                room.transform.parent = gameObject.transform.parent;
            }else if (openingDirection == 1) {
                rand = Random.Range(0, templates.bottomDoorRooms.Length - 1);
                var room = Instantiate(templates.bottomDoorRooms[rand],transform.position,Quaternion.identity);
                room.transform.parent = gameObject.transform.parent;
            }else if (openingDirection == 2) {
                rand = Random.Range(0, templates.leftDoorRooms.Length - 1);
                var room = Instantiate(templates.leftDoorRooms[rand],transform.position,Quaternion.identity);
                room.transform.parent = gameObject.transform.parent;
            }
            spawned = true;
        }
    }

    private void Spawn()
    {
        if (spawned == false)
        {

            if (openingDirection == 3 && GameManager.instance.b < Random.Range(0.0f,1.0f))
            {
                rand = Random.Range(0, templates.topDoorRooms.Length - 1);
                var room = Instantiate(templates.roomA,transform.position,Quaternion.identity);
                room.transform.parent = GameObject.FindGameObjectWithTag("Rooms").transform;
                
            }else if (openingDirection == 4 && GameManager.instance.l < Random.Range(0.0f,1.0f)) {
                
                rand = Random.Range(0, templates.rightDoorRooms.Length - 1);
                var room = Instantiate(templates.roomA,transform.position,Quaternion.identity);
                room.transform.parent = GameObject.FindGameObjectWithTag("Rooms").transform;
                
            }else if (openingDirection == 1 && GameManager.instance.t < Random.Range(0.0f,1.0f)) {
                
                rand = Random.Range(0, templates.bottomDoorRooms.Length - 1);
                var room = Instantiate(templates.roomA,transform.position,Quaternion.identity);
                room.transform.parent = GameObject.FindGameObjectWithTag("Rooms").transform;
                
            }else if (openingDirection == 2 && GameManager.instance.r < Random.Range(0.0f,1.0f)) {
                
                rand = Random.Range(0, templates.leftDoorRooms.Length - 1);
                var room = Instantiate(templates.roomA,transform.position,Quaternion.identity);
                room.transform.parent = GameObject.FindGameObjectWithTag("Rooms").transform;
                
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
