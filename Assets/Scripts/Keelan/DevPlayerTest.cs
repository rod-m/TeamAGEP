using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPlayerTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            transform.Translate(Vector3.forward * 0.1f);
        }
    }
}
