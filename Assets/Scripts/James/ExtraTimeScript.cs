using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Item that adds extra time on collected by player
 */
public class ExtraTimeScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Extra Time Picked Up");
            Destroy(gameObject);
        }
    }
}
