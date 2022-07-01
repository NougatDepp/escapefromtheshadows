using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Mover
{
    public float speed = 2f;
    public float change = 1f;

    public float lastTime;
    public float cooldown = 5f;
    
    private bool collidingWithPlayer;
    
    private Transform playerTransform;
    private Vector3 startingPosition;

    private Vector3 direction;
    
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

        if (Time.time - lastTime > cooldown)
        {
            direction = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), 0);
            lastTime = Time.time;
        }
            
        
        UpdateMotor((direction).normalized*speed,change);
        
            
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

}

