using System;
using System.Collections;
using System.Collections.Generic;
using Chris;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public int score = 1;

    private void Update()
    {
        transform.Rotate(transform.up * 1f);
    }

    void Collected()
    {
        //score++; // todo Link this to score board
        HUDScript.Instance.Collected += score;
        //Accesses value in HUD singleton
       // Debug.Log($"Score: {score}");  // house keep!, comment out logs once finished debugging
        // no one else wants to see your log dumps!
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected(); // good use of methods
        }
    }
}
