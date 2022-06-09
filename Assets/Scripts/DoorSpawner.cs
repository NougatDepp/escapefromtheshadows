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
        temps = GameObject.FindGameObjectWithTag("Doors").GetComponent<DoorTemplates>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DoorT"))
        {
            Instantiate(temps.normalDoors[0], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }else if(other.CompareTag("DoorR"))
        {
            Instantiate(temps.normalDoors[1], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }else if(other.CompareTag("DoorB"))
        {
            Instantiate(temps.normalDoors[2], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }else if(other.CompareTag("DoorL"))
        {
            Instantiate(temps.normalDoors[3], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
