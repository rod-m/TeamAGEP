using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private int score = 0;

    private void Update()
    {
        transform.Rotate(transform.up * 1f);
    }

    void Collected()
    {
        score++; // todo Link this to score board
        Debug.Log($"Score: {score}");  // house keep!, comment out logs once finished debugging
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
