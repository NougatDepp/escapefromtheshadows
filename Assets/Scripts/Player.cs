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
    public bool dead = false;
    public int damage = 1;

    public GameObject deathMenuUi;
    public GameObject winMenuUi;
    
    public HealthBarScript healthBar;
    
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GameManager.instance.Checkpoint = transform.position;
        PlayerPrefs.GetFloat("diff");
        immuneTime = 2f;
        
        healthBar.SetMaxHealth(maxHitpoint);
        
    }
    
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (!dead) Mover(x,y);

        healthBar.SetHealth(hitpoint);
        
        anim.SetFloat("Hitpoints",hitpoint);

        if (x != 0 || y != 0)
        {
            if(!dead)GameManager.instance.moving = true;
        }
        else
        {
            GameManager.instance.moving = false;
        }
        
        if(Random.Range(1,300) == 50) anim.SetTrigger("Blink");
        
        if(hitpoint <= 0)DeadOn();
        
        var colorvar = gameObject.GetComponent<SpriteRenderer>().color;

        if (Time.time - lastImmune > immuneTime)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(colorvar.r, colorvar.g, colorvar.b, 1f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(colorvar.r, colorvar.g, colorvar.b, 0.3f);
        }
    }

    public void Spawn()
    {
        
    }

    public void Mover(float x, float y)
    {
        PlayerMotor(new Vector3(x,y,0).normalized);
    }
    
    public void DeadOn()
    {
        dead = true;
    }
    
    public void DeadOff()
    {
        dead = false;
    }

    public void DeathScreen()
    {
        Time.timeScale = 0;
        deathMenuUi.SetActive(true);
    }

    public void WinScreen()
    {
        Time.timeScale = 0;
        winMenuUi.SetActive(true);
    }
    
    public void Freeze()
    {
        this.enabled = false;
    }
    
    public void Unfreeze()
    {
        this.enabled = true;
    }
}
