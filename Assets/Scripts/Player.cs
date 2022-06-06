using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : Mover
{
    public static float darkness = 1f;
    public static int hearts = 3;
    public static int lives = 3;
    public static Vector3 Checkpoint;
    public static bool moving = false;
    public bool dead = false;

    private bool respawn = false;


    private SpriteRenderer spriteRenderer;
    private Animator anim;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Checkpoint = transform.position;
        
    }
    
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (!dead) PlayerMotor(new Vector3(x,y,0).normalized);

        anim.SetInteger("Hearts",hearts);

        if (darkness <= 0)
        {
            hearts -= 1;
            darkness = 1f;
        }

        if (x != 0 || y != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        
        if (Vector3.Distance(gameObject.transform.position, Checkpoint) > 0.1f  && respawn)
        {
            gameObject.transform.position -= (gameObject.transform.position - Checkpoint).normalized/10;
            if (gameObject.transform.position.magnitude <= Checkpoint.magnitude+0.1f) anim.SetTrigger("Respawn");
        }
        else
        {
            respawn = false;
        }
        
        if(Random.Range(1,300) == 50) anim.SetTrigger("Blink");
    }

    public void DeadOn()
    {
        dead = true;
    }
    
    public void DeadOff()
    {
        dead = false;
    }
    
    public void Respawn()
    {
        if (lives > 1)
        {
            darkness = 1; 
            hearts = 3;
            respawn = true;
            lives -= 1;
        }
        else
        {
            SceneManager.LoadScene(0);
            darkness = 1;
            hearts = 3;
            lives = 3;
            
        }
        
    }

    public void SetLives(float lives)
    {
        Player.lives = (int)lives;
    }
    
    public void Freeze()
    {
        this.enabled = false;
    }
    
    public void Unfreeze()
    {
        this.enabled = true;
    }

    public void Movement(float x, float y)
    {
            
    }
    
}
