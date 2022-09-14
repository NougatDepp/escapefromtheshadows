using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : Mover
{
    
    public float speed = 0.5f;
    public float change = 1f;
    
    private bool collidingWithPlayer;
    
    private Transform playerTransform;
    private Vector3 startingPosition;
    
    // Hitbox
    public ContactFilter2D filter;

    private Collider2D[] hits = new Collider2D[10];
    

    protected override void Start()
    {
        base.Start();
        playerTransform = FindObjectOfType<GameManager>().player.transform;
        startingPosition = transform.position;
        enabled = false;
    }
    
    void OnBecameVisible()
    {
        enabled = true;
    }
    
    void OnBecameInvisible()
    {
        transform.position = startingPosition;
        hitpoint = maxHitpoint;
        
        enabled = false;
    }
    
    private void FixedUpdate()
    {

        if (!collidingWithPlayer)
        {
            UpdateMotor((playerTransform.position-transform.position).normalized*speed,change);
        }
            
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }
            
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        GameManager.instance.player.damage += 1;
        Destroy(gameObject);
    }
    

    public void SetHealth (float diff)
    {
        hitpoint = (int)Mathf.Round(diff);
        speed = diff/2;
    }
    
}
