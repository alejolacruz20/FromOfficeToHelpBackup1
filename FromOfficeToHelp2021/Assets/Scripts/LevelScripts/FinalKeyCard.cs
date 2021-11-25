using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyCard : Control_Llave
{
    // Update is called once per frame
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            rend.gameObject.SetActive(false);
            Blocked_Door.finalTaken = true;
            base.Update();
        }
    }
}
