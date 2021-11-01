using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GeneralEntitiesLife
{
    public Animator anim;
    public RandomMovement randomMovement;
    public Waypoints waypointsMovement;
    public bool spawnDeathParticles = true;
    public ParticleSystem deathParticles;
    public Transform spawnParticlePoint;

    public override void ZeroLife()
    {
        spawnDeathParticles = true;

        if (randomMovement != null)
        {
            randomMovement.enabled = false;
            //anim.SetBool("Freedom", true);
            //base.Death();
        }
        else if (waypointsMovement != null)
        {
            waypointsMovement.enabled = false;
            //anim.SetBool("Freedom", true);
            //base.Death();
        }

        //if(spawnDeathParticles == true)
        //{
        //    Instantiate(deathParticles, spawnParticlePoint.position, spawnParticlePoint.rotation);
        //    spawnDeathParticles = false;
        //}

        anim.SetBool("Freedom", true);
        base.ZeroLife();
    }

    public void SpawnParticles()
    {
        Instantiate(deathParticles, spawnParticlePoint.position, spawnParticlePoint.rotation);
    }
}
