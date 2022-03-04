using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVisonScript : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    bool isAlarm;
    [SerializeField]
    public EnemyNavmeshWaypoints EnemyNavmeshWaypoints;
    [SerializeField]
    private Transform raycastPoint;
    [SerializeField]
    private LayerMask raycastLayers;
    [SerializeField]
    private float raycastDistance;
    [SerializeField]
    private RaycastHit raycastHit;
    [SerializeField]
    public bool inSight; 


    public void PlayerDetection()
    {
        animator.SetBool("Spotted", true);
        //EnemyNavmeshWaypoints.enemyAction = EnemyNavmeshWaypoints.IsStay;
    }

    private void Awake()
    {
        inSight = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Physics.Raycast(raycastPoint.position, other.transform.position - raycastPoint.position, out raycastHit, raycastDistance, raycastLayers))
        {
            Debug.DrawRay(raycastPoint.transform.position, other.transform.position - raycastPoint.position, Color.red, 1f);
            if (other.gameObject.layer == 9)
            {
                if (raycastHit.collider == other)
                {
                    Debug.Log(other.gameObject.name);
                    inSight = true;
                    PlayerDetection();
                }
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
                EnemyNavmeshWaypoints.enemyAction = EnemyNavmeshWaypoints.IsWalking;
                animator.SetBool("Spotted", false);
                animator.SetBool("IsRunning", false);
            }
        }
    }

}
