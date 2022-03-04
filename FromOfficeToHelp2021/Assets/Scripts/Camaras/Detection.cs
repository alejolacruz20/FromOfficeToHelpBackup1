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
    private float      timer;
    [SerializeField]
    public GameObject guardias;
    

    public GameObject[] origenGuardia;

    bool spawnChecker = false; 


    //private bool isPatrolling;


    private void Awake()
    {
        
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
        

            if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit, raycastDistance, raycastLayers))
            {
                Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.red, 1f);
                

                if (raycastHit.collider == other)
                {
                    Debug.Log(other.gameObject.name);
                    inSight = true;
                    PlayerDetection();
                }
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
            if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit, raycastDistance, raycastLayers))
            {
                Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.magenta, 1f);

                if (raycastHit.collider == other)
                {
                    inSight = false;
                    timer = 0f;
                    spawnChecker = false;
                }
            }
        
    }

    public virtual void PlayerDetection() //FUNCION QUE LLAMA A LOS GUARDIAS 
    {
        if (inSight && timer >= 3f && spawnChecker == false)
        {
            for (int i = 0; i < origenGuardia.Length; i++)
            {
                Instantiate(guardias, origenGuardia[i].transform.position, origenGuardia[i].transform.rotation);
            }
            Debug.Log("LLAMAR GUARDIAS");
            spawnChecker = true;
        }
    }
}
