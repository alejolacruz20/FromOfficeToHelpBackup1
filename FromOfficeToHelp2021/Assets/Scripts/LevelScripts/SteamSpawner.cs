using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSpawner : MonoBehaviour
{
    public Transform[] shootingPoints;
    // public Animator[] enemyAnim;
    public GameObject steamParticle;
    public float chronometer;
    public float limitChronometer;

    // Update is called once per frame
    void Update()
    {
        chronometer += Time.deltaTime;

        if (chronometer >= limitChronometer)
        {
            for(int i = 0; i < shootingPoints.Length; i++)
            {
                Instantiate(steamParticle, shootingPoints[i].transform.position, shootingPoints[i].transform.rotation);
                //enemyAnim[index].SetBool("nombre", true);
                chronometer = 0;
            }
        }

    }
}
