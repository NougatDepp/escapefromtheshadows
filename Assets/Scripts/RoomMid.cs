using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomMid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint")) Destroy(other.gameObject);
        if(other.CompareTag("SecretRoom")) Destroy(other.gameObject);
    }
}
