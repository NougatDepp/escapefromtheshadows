using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSpawn : Collidable
{
    public int count = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpecialRoom")||other.CompareTag("Treasure")||other.CompareTag("Boss"))
        {
            gameObject.tag = "Secret";
            other.gameObject.tag = "Secret";
        }
    }
}