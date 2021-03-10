using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField]private DevPlayerTest player;

    private float speedMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffects();
        }
    }

    void ApplyEffects()
    {
        if (this.CompareTag("SpeedUp"))
        {
            player.speed *= speedMultiplier;
        }

        GetComponent<Renderer>().enabled = false;

        Invoke("ReverseEffects", 5f);
    }

    void ReverseEffects()
    {
        if (this.CompareTag("SpeedUp"))
        {
            player.speed /= speedMultiplier;
        }
        
        Destroy(gameObject);
    }
    
}
