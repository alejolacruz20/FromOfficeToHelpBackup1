using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem damageParticles;
    public Transform[] bulletParticlePoints;

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("PlayerBullet"))
        {
            Particles(); 
        }
    }
   
    public void Particles()
    {
        for (int i = 0; i < bulletParticlePoints.Length; i++)
        {
            Instantiate(damageParticles, bulletParticlePoints[i].position, bulletParticlePoints[i].rotation);
        }
    }
}
