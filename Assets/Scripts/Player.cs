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

    private SpriteRenderer spriteRenderer;
    private Animator anim;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GameManager.instance.Checkpoint = transform.position;
        
    }
    
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (!dead) PlayerMotor(new Vector3(x,y,0).normalized);

        anim.SetInteger("Hearts",GameManager.instance.hearts);

        if (GameManager.instance.darkness <= 0)
        {
            GameManager.instance.hearts -= 1;
            GameManager.instance.darkness = 1f;
        }

        if (x != 0 || y != 0)
        {
            GameManager.instance.moving = true;
        }
        else
        {
            GameManager.instance.moving = false;
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

    public void Freeze()
    {
        this.enabled = false;
    }
    
    public void Unfreeze()
    {
        this.enabled = true;
    }
}
