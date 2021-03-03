using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private int score = 0;

    void Collected()
    {
        Destroy(gameObject);
        score++;
        Debug.Log($"Score: {score}");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected();
        }
    }
}
