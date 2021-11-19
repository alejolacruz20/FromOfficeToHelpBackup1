using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    protected int _waypointIndex;
    public float dist;

    public void Start()
    { 
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
        transform.Translate(new Vector3(0, 0, 2 * Time.deltaTime));
    }
     
    public void IncreaseIndex()
    {
        
        
            _waypointIndex++;
            if (_waypointIndex >= waypoints.Length)
            {
                MaxIndex();
            }
            transform.LookAt(waypoints[_waypointIndex].position);
        
    }

    public virtual void MaxIndex()
    {
        _waypointIndex = 0;
    }
}
