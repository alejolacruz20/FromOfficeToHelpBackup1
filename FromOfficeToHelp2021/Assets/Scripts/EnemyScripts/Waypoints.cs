using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Gabriel Ceriani y Tiago Zedde
public class Waypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    protected int _waypointIndex;
    public float dist;
    public bool fightingPlayer = false;
    public GameObject playerTarget;
    public Animator anim;
    public float minDistance;

    public void Start()
    {
        fightingPlayer = false;
        _waypointIndex = 0;
        transform.LookAt(waypoints[_waypointIndex].position);
    }

    public virtual void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[_waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }

        IsFighting();
    }

    public virtual void IsFighting()
    {
        if (Vector3.Distance(playerTarget.transform.position, transform.position) > minDistance)
        {
            anim.SetBool("PlayerAttack", false);
            fightingPlayer = false;
            transform.Translate(new Vector3(0, 0, 2 * Time.deltaTime));
            transform.LookAt(waypoints[_waypointIndex].position);
        }
        else
        {
            if(fightingPlayer == false)
            {
                transform.LookAt(new Vector3(playerTarget.transform.position.x, transform.position.y, playerTarget.transform.position.z));
                Debug.Log("Atacando");
                anim.SetBool("PlayerAttack", true);
                fightingPlayer = true;
            }
        }
    }

    public virtual void EndAnimation()
    {
        anim.SetBool("PlayerAttack", false);
        fightingPlayer = false;
    }

    //public void Patrol()
    //{
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //}

    public void IncreaseIndex()
    {
        if (fightingPlayer == false)
        {
            _waypointIndex++;
            if (_waypointIndex >= waypoints.Length)
            {
                MaxIndex();
            }
            transform.LookAt(waypoints[_waypointIndex].position);
        }
    }

    public virtual void MaxIndex()
    {
        _waypointIndex = 0;
    }
}