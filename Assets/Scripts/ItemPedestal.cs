using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPedestal : Collidable
{

    private Vector3 startingPosition;
    private Transform playerTransform;
    protected override void Start()
    {
        base.Start();
        startingPosition = transform.position;
        playerTransform = GameManager.instance.player.transform;
    }

    void FixedUpdate()
    {
        if (transform.position != startingPosition)
        {
            GameManager.instance.player.Mover(-(transform.position.x - startingPosition.x),
                -(transform.position.y - startingPosition.y));
            transform.position = Vector3.Lerp(transform.position, startingPosition, 5);
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        
    }
}
