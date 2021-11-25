using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyCard : Control_Llave
{
    AudioManager AudioManager;

    private void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            AudioManager.Play("Pickup");
            rend.gameObject.SetActive(false);
            Blocked_Door.finalTaken = true;
            base.Update();
        }
    }
}
