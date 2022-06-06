using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DoorSpawner : MonoBehaviour
{
    public bool spawned = false;
    private DoorTemplates temps;
    private int rand;
        
    private void Start()
    {
        temps = GameObject.FindGameObjectWithTag("Doors").GetComponent<DoorTemplates>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Doorsx"))
        {
            
            Instantiate(temps.normalDoors[0], transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            
        }else if(other.CompareTag("Doorsy"))
        {
            
            
            Instantiate(temps.normalDoors[1], transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            
        }
    }

}
