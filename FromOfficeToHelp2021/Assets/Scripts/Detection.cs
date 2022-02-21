using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    //CREADOR: LUCAS OLIVARES

    [SerializeField]
    private LayerMask  raycastLayers;
    [SerializeField]
    private Transform  raycastPoint;
    [SerializeField]
    private float      raycastDistance;
    [SerializeField]
    private RaycastHit raycastHit;

    private void OnTriggerStay(Collider other)
    {
        if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit,raycastDistance, raycastLayers))
        {
            Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.red, 20f);

            if (raycastHit.collider == other)
            {
                Debug.Log(other.gameObject.name);
            }
        }
    }
}
