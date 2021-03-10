using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPlayerTest : MonoBehaviour
{
    public float speed = 0.1f;
    
    void Update()
    {
        Debug.Log(speed);
        
        if (Input.GetButton("Jump"))
        {
            transform.Translate(Vector3.forward * speed);
        }
    }
}
