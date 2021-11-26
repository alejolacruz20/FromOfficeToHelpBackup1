using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlConnector : Control_Llave
{
    AudioManager AudioManager;

    private void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
    }

    public override void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        {
            CentroEnergia.playerHaveTheConnector = true;
            AudioManager.Play("Pickup");
            rend.gameObject.SetActive(false);
        }
    }
}
