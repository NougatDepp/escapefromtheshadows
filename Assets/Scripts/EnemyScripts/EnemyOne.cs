using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyOne : Mover
{

    public float speed = 0.5f;
    public float change = 1f;
    
    private bool collidingWithPlayer;
    
    private Transform playerTransform;
    private Vector3 startingPosition;
    
    // Hitbox
    public ContactFilter2D filter;

    private Collider2D[] hits = new Collider2D[10];
    
    public GameObject fireball;
    public float launchForce;
    public Transform shotPoint;
    
    public float cooldown;
    public float lastShot;
    

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
            FloatUpdateMotor((playerTransform.position-transform.position).normalized*speed,change);
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
        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        
        GameObject newFireball = Instantiate(fireball, shotPoint.position, Quaternion.identity);
        newFireball.GetComponent<Rigidbody2D>().velocity = (GameManager.instance.player.transform.position-transform.position).normalized*launchForce;

        lastShot = Time.time;

    }
    
    protected override void Death()
    {
        GameManager.instance.player.damage += 1;
        Destroy(gameObject);
    }
    
}
