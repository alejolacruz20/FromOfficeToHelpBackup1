using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class DisparoHorizontal : MonoBehaviour
{
    public GameObject[] shootingPoints;
   // public Animator[] enemyAnim;
    public GameObject bullet;
    public float chronometer;
    public float limitChronometer;
    public int index;

    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        chronometer += Time.deltaTime;

        if (index > shootingPoints.Length - 1)
        {
            index = 0;
        }

        if (chronometer >= limitChronometer)
        {
            Instantiate(bullet, shootingPoints[index].transform.position, shootingPoints[index].transform.rotation);
            //enemyAnim[index].SetBool("nombre", true);
            chronometer = 0;
            index++;
        }

    }
}
