using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessParticles : MonoBehaviour
{
    //TPFINAL: CERIANI, LACRUZ

    public Transform[] happyPointsSpawner;
    public GameObject happyParticles;
    public AudioSource audioclipHappiness;
    bool dontSpawn = false;
    public ActivatedScreens activatedScreens;
   
    void Start()
    {
        activatedScreens.onActivatedScreens += OnSpawnParticles;
    }

    public void OnSpawnParticles()
    {
        if (!dontSpawn)
        {
            for (int k = 0; k < happyPointsSpawner.Length; k++)
            {
                Instantiate(happyParticles, happyPointsSpawner[k].transform.position, happyPointsSpawner[k].transform.rotation);
                audioclipHappiness.Play();

                if (k == happyPointsSpawner.Length - 1)
                {
                    dontSpawn = true;
                }
            }
        }
    }
}
