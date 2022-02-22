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
    [SerializeField]
    private TestCamara testCamara;
    [SerializeField]
    public bool inSight;
    [SerializeField]
    private float timer;

    private bool isPatrolling;


    private void Awake()
    {
        isPatrolling = true;
        inSight = false;
    }

    private void Update() 
    {
        if (inSight)
        {
            timer = timer + Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (isPatrolling)
        {
            if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit, raycastDistance, raycastLayers))
            {
                Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.red, 1f);

                if (raycastHit.collider == other)
                {
                    Debug.Log(other.gameObject.name);
                    inSight = true;
                    PlayerDetection();
                }
                else
                {
                    inSight = false;
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
                Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.magenta, 1f);

                if (raycastHit.collider == other)
                {
                    inSight = false;
                    timer = 0f;
                }
            }
        }
    }

    public void PlayerDetection() 
    {
        if (inSight && timer >= 3f)
        {
            Debug.Log("LLAMAR GUARDIAS UWU"); 

        }
    }
}
