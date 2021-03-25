using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Opens up/removes a door somewhere in the level
 */
public class KeyScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Key Picked Up");
            Destroy(gameObject);
        }
    }
}
