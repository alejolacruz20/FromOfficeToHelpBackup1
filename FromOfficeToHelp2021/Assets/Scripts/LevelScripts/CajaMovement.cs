using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class CajaMovement : MonoBehaviour
{
    public float speed;
    public Quaternion angle;
    public float degree;

    private void Start()
    {
        degree = 0;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        angle = Quaternion.Euler(0, degree, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 5); 
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Walls"))
        {
            degree += 180;
        }
    }

    public void DegreeVariation(int amount) 
    {
        degree = amount;
    }
}
