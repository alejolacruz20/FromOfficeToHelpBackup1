using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem hitParticles;
    public Transform bulletParticlePoints;

    public void Start()
    {
        bulletParticlePoints = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider target)
    {
        Particles(); 
    }
   
    public void Particles()
    {
        Instantiate(hitParticles, bulletParticlePoints.position, bulletParticlePoints.rotation);
    }
}
