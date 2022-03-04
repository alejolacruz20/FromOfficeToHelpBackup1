using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyNavmeshWaypoints : MonoBehaviour
{
    public GameObject playerTarget;
    protected int _indexWaypoint; 
    public Transform[] waypoints; 
    public float dist;
    public NavMeshAgent myAgent;
    public Action enemyAction;
    public int minDistance;
    public Animator anim;
    public GameObject target;


    void Start()
    {
        _indexWaypoint = 0;
        myAgent.speed = 3.5f;
        enemyAction = IsWalking;
    }

    void Update()
    {
        //dist = Vector3.Distance(transform.position, waypoints[_indexWaypoint].position);
        //if (dist < 2f)
        //{
        //    IncreaseIndex();
        //}
        enemyAction?.Invoke();
    }

    public void IncreaseIndex()
    {
            _indexWaypoint++;
            if (_indexWaypoint >= waypoints.Length)
            {
                _indexWaypoint = 0;
            }
    }

    public virtual void IsWalking() 
    {
        myAgent.SetDestination(waypoints[_indexWaypoint].transform.position); //SETEA DESTINO AL ARRAY 

        dist = Vector3.Distance(transform.position, waypoints[_indexWaypoint].position);
        if (dist < 2f)
        {
            IncreaseIndex();
        }
    }

    public virtual void IsFollowing() 
    {
        myAgent.SetDestination(target.transform.position); //SETEA DIRECCION AL JUGADOR 
    }

    //public virtual void IsStay() 
    //{
    //    transform.LookAt(target.transform.position);

    //}

    public virtual void IsRunning() 
    {
        anim.SetBool("IsRunning", true);
        enemyAction = IsFollowing;
    } 
}

   
