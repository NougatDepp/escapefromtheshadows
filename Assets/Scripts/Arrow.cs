using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 1;
    protected override void OnCollide(Collider2D coll)
    {
        
        if (coll.tag == "Fighter")
        {
            if(coll.name == "Player")
            {
                return;
            }

            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage",dmg);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5f) GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.02f);
        if (GetComponent<SpriteRenderer>().color.a <= 0) Destroy(gameObject);
        gameObject.GetComponent<Rigidbody2D>().velocity -= gameObject.GetComponent<Rigidbody2D>().velocity/20;
    }
}
