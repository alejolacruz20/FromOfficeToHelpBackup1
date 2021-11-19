using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPalanca : Control_Llave
{
    public override void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        {
            CentroEnergia.playerHaveTheLever = true;
            FindObjectOfType<AudioManager>().Play("Pickup");
            rend.gameObject.SetActive(false);
        }
    }
}
