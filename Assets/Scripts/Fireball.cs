using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 1;
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
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude <= 0.3f) Destroy(gameObject);
        gameObject.GetComponent<Rigidbody2D>().velocity -= gameObject.GetComponent<Rigidbody2D>().velocity/20;
    }
}
