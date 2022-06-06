using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Player.moving)
        {
            anim.SetBool("Walk",true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    public void Walk()
    {
        anim.SetBool("Walk",true);
    }
    
    public void StopWalk()
    {
        anim.SetBool("Walk", false);
    }
    
}
