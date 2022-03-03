using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyNavmeshWaypoints : MonoBehaviour
{
    public GameObject playerTarget; //ESTE 
    protected int _indexWaypoint; //ESTE
    public Transform[] waypoints; //ESTE
    public float dist;
    public NavMeshAgent myAgent;
    Action enemyAction;
    bool fightingPlayer = false;
    public int minDistance;
    public Animator anim;


    void Start()
    {
        _indexWaypoint = 0;
       
        myAgent.speed = 3.5f;
        enemyAction = IsWalking;
    }

    
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[_indexWaypoint].position);
        if (dist < 2f)
        {
            IncreaseIndex();
        }
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
    }

   
}
