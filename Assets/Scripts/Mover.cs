using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {

        moveDelta.x = input.x*2;
        moveDelta.y = input.y*2;

        // Add push Vector, if any
        moveDelta += pushDirection;
        
        //Reduce pushforce every frame
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //Hit Objects
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0,0);
        }
    }
    
    protected virtual void PlayerMotor(Vector3 input)
    {

        moveDelta.x = input.x*2;
        moveDelta.y = input.y*2;

        // Add push Vector, if any
        moveDelta += pushDirection;
        
        //Reduce pushforce every frame
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //Hit Objects
        hit = Physics2D.BoxCast(transform.position - new Vector3(0, 0.1f,0), new Vector2(0.01f,0.01f), 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position  - new Vector3(0, 0.1f,0), new Vector2(0.01f,0.01f), 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0,0);
        }
    }
    
    protected virtual void RespawnCam(Vector3 location)
    {
        Player.lives -= 1;
        gameObject.transform.position = location;
    }
   
}
