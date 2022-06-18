using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collidable
{
    public int damagePoint = 5;
    public float pushForce = 1;

    public float vanish = 1;
    public bool vanishing = false;

    private void FixedUpdate()
    {
        
    }

    protected override void OnCollide(Collider2D coll)
    {
        
        if (coll.tag == "Fighter")
        {
            
        }
        else
        {
            Debug.Log(coll.tag);
            if (coll.CompareTag("Breakable")) Destroy(coll.gameObject);
        }

        
    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
