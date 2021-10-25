using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject explosionParticles;

    private void OnCollisionEnter(Collision target)
    {
        Destroy();
    }

    public void Destroy()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
    }
}
