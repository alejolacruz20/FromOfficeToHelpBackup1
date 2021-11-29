using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickUps : MonoBehaviour
{
    private void OnTriggerEnter(Collider target)
    {
        var pickUp = target.GetComponent<IgeneralPickUp>();

        if (pickUp != null)
        {
            pickUp.Actions();
            FindObjectOfType<AudioManager>().Play("Pickup");
        }
    }

    private void OnTriggerStay(Collider target)
    {
        LockDoors lockDoors = target.GetComponent<LockDoors>();
        if (lockDoors != null)
        {
            if (KeyInventory.keys[lockDoors.index] == true)
            {
                lockDoors.ChangeDoorState();
               
            }
        }
    }
}
