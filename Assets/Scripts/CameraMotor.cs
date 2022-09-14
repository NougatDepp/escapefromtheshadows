using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public static Vector3 newPos;
    private void Start()
    {
        newPos = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime*10);
        
    }

}
