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
    //[SerializeField]
    //private TestCamara testCamara;
    [SerializeField]
    private float detectionTime;
    //[SerializeField]
    //private bool inSight = false;

    private bool isPatrolling;


    private void Awake()
    {
        isPatrolling = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPatrolling)
        {
            if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit, raycastDistance, raycastLayers))
            {
                Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.red, 2f);

                if (raycastHit.collider == other)
                {
                    Debug.Log(other.gameObject.name);
                    TimeDetection();
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (isPatrolling)
        {
            if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit, raycastDistance, raycastLayers))
            {
                Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.magenta, 2f);
            }
        }
    }


    void TimeDetection() 
    {
        detectionTime = Time.deltaTime;
              
        if (detectionTime >= 3f)
        {
            Debug.Log("Suena la alarma ");
        }
        else
        {
            Debug.Log("No suena la alarma ");
        }
    }

    
   
        
    
}
