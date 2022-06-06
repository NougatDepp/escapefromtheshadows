using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPos : MonoBehaviour
{
    private Transform playerTransform;
    
    private void Start()
    {
        playerTransform = GameManager.instance.player.transform;
    }
    void Update()
    {
        Vector2 bowPosition = playerTransform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        Vector2 dirVec = new Vector3(1f-Mathf.Pow(2.71f,-direction.magnitude),0);
        transform.localPosition = dirVec;
    }
}
