using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BombPlanter : MonoBehaviour
{
    public GameObject bomb;
    private Transform playerTransform;
    
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&GameObject.FindGameObjectsWithTag("Bomb").Length<=2)
        {
            Plant();
        }
    }

    void Plant()
    {
        GameObject newBomb = Instantiate(bomb, transform.position, Quaternion.identity);
    }
}
