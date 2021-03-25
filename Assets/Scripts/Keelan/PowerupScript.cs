using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField]private DevPlayerTest player;
    private IPowerUpEffect playa;

    private void OnTriggerEnter(Collider other)
    {
        //check for player
        if (other.CompareTag("Player"))
        {
            playa = other.GetComponent<IPowerUpEffect>();
            ApplyEffects();
        }
    }

    void ApplyEffects()
    {
        //this speedup tag check can be made better through use of an interface I think, but unsure as how right now
        playa.PowerUpEffects(2f, transform.tag);

        //doesnt destroy object with script, just removes the mesh so it cant be seen
        GetComponent<Renderer>().enabled = false;

        //reverse after short duration
        Invoke("ReverseEffects", 5f);
    }

    void ReverseEffects()
    {
        playa.PowerUpEffects(0.5f, transform.tag);
        
        //then destroy
        Destroy(gameObject);
    }
}
