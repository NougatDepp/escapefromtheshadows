using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : Mover
{
    // Experience
    public int xpValue = 1;
    
    //Logic
    public float triggerLength = 1;
    public float chaseLength = 5;
    private bool chasing;
    public float speed = 0.5f;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    
    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    

    protected override void Start()
    {
        base.Start();
        playerTransform = FindObjectOfType<GameManager>().player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        
    }
    
    void OnBecameVisible()
    {
        enabled = true;
    }
    
    void OnBecameInvisible()
    {
        enabled = false;
    }
    
    private void FixedUpdate()
    {
        // Is the player in range?
        if (Physics2D.Raycast(transform.position, (playerTransform.position-transform.position).normalized, chaseLength,768))
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                chasing = true;
            
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position-transform.position).normalized*speed);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }
        
        //Check for overlaps
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
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        //GameManager.instance.ShowText("+"+ xpValue+" xp",15,Color.green, transform.position,Vector3.one*50,0.5f);
    }

    public void ChaseBait()
    {
        
    }

    public void SetHealth (float diff)
    {
        hitpoint = (int)Mathf.Round(diff);
        speed = diff/2;
    }
}
