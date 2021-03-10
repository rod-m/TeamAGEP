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
        //check for player
        if (other.CompareTag("Player"))
        {
            ApplyEffects();
        }
    }

    void ApplyEffects()
    {
        //this speedup tag check can be made better through use of an interface I think, but unsure as how right now
        if (this.CompareTag("SpeedUp"))
        {
            player.speed *= speedMultiplier;
            //applies
        }

        //doesnt destroy object with script, just removes the mesh so it cant be seen
        GetComponent<Renderer>().enabled = false;

        //reverse after short duration
        Invoke("ReverseEffects", 5f);
    }

    void ReverseEffects()
    {
        if (this.CompareTag("SpeedUp"))
        {
            //reverse
            player.speed /= speedMultiplier;
        }
        
        //then destroy
        Destroy(gameObject);
    }
}
