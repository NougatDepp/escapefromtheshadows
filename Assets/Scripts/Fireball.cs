using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 1;
    private Vector3 start;


    protected override void Start()
    {
        base.Start();
        start = transform.position;
    }
    
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        { 
            Damage dmg = new Damage()
            { 
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage",dmg);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (coll.tag != "Untagged" && coll.tag != "Enemy") Destroy(gameObject);
        if (coll.name == "Collision") Destroy(gameObject);
        if (coll.name == "Fireball(Clone)") Destroy(gameObject);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.magnitude - start.magnitude > 1) Destroy(gameObject);
    }
}
