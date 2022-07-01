using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public Fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    
    //Immunity
    protected float immuneTime = 0;
    protected float lastImmune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {

        lastImmune = Time.time; 
        hitpoint -= dmg.damageAmount; 
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }
    }

    protected virtual void Death()
    {
        
    }
}
