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

    public float vanish = 1;
    public bool vanishing = false;
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
            
            Debug.Log(coll.name);

            
        }
        
    }

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude < 3) GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.02f);
        if (GetComponent<SpriteRenderer>().color.a <= 0) Destroy(gameObject);
    }
    
    
}
