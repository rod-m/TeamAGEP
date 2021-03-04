using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Jake consider what you can add to this to give it more flexability
 * Is it key activated
 * Does it have animation
 * Does it play a sound
 * Does it have a cooldown period
 * etc
 */
public class Teleport : MonoBehaviour
{
    Quaternion startRotation = Quaternion.Euler(Vector3.zero);
   [SerializeField] 
    private Transform Player;
    [SerializeField] 
    private Transform Desination;
    void OnTriggerEnter(Collider other)
    {
        //print("teleporting: "+ Player.position.ToString() +" to " + Desination.position.ToString());
        //Player.transform.position = Desination.transform.position;
        // note that when using CharacterController you need to disable it while setting position
        // https://answers.unity.com/questions/1614287/teleporting-character-issue-with-transformposition.html
        CharacterController cc = Player.gameObject.GetComponent<CharacterController>();
        if(cc != null)
            cc.enabled = false;
        Player.SetPositionAndRotation(Desination.position, startRotation);
        if(cc != null)
            cc.enabled = true;
        //var transformPosition = Player.transform.position;
        //transformPosition.y += 1.5f;  // what does this do?
    }
}