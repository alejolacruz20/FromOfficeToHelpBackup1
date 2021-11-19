using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaCollider : MonoBehaviour
{
    public int degreeNumber;
    public CajaMovement caja;

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("PlayerBullet"))
        {
            caja.DegreeVariation(degreeNumber); 
        }
    }
}
