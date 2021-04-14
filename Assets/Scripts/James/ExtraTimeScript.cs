using System;
using System.Collections;
using System.Collections.Generic;
using Chris;
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
            // Note: you can use the HUDScript to register time pickups
            /*
             * HUDScript.Instance.Collected += score;
             * HUDScript.Instance.TimePickup += timePickedUp
             * or HUDScript.Instance.SetTimePickedUp();
             *
             * A good approach would be to use an interface
             */
            IPickUpTime _pick = HUDScript.Instance as IPickUpTime;
            if (_pick != null)
            {
                _pick.PickUpTime();
            }
            else
            {
                Debug.LogError("IPickUpTime is not implemented!");
            }
            
            print("Extra Time Picked Up");
            Destroy(gameObject);
        }
    }
}
