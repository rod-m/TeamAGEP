using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Desination;
    void OnTriggerEnter(Collider other)
    {
        print("teleporting: "+ Player +" to " + Desination);
        Player.transform.position = Desination.transform.position;
        var transformPosition = Player.transform.position;
        transformPosition.y += 1.5f;
    }
}