using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomMid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint")) Destroy(other.gameObject);
        if(other.CompareTag("SpecialRoom")) Destroy(other.gameObject);
        if(other.CompareTag("Secret")) Destroy(other.gameObject);
        if(other.CompareTag("Boss")) Destroy(other.gameObject);
        if(other.CompareTag("Treasure")) Destroy(other.gameObject);
        
    }
}
