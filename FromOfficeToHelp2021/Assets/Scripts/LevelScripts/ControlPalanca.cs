using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPalanca : MonoBehaviour, IgeneralPickUp
{
    public void Actions()
    {
        CentroEnergia.playerHaveTheLever = true;
        Destroy(this.gameObject);
    }
}
