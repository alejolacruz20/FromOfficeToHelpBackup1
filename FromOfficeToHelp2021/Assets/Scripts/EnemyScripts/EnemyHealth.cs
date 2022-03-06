using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GeneralEntitiesLife
{
    //TPFINAL: ZEDDE, OLIVARES, CERIANI

    public Animator anim;
    public RandomMovement randomMovement;
    public Waypoints waypointsMovement;
    public bool spawnDeathParticles = true;
    public ParticleSystem deathParticles;
    public Transform spawnParticlePoint;
    public EnemyNavmeshWaypoints enemyNavmeshWaypoints;

    public override void ZeroLife()
    {
        spawnDeathParticles = true;

        if (randomMovement != null)
        {
            randomMovement.enabled = false;
        }
        else if (waypointsMovement != null)
        {
            waypointsMovement.enabled = false;
        }

        anim.SetBool("Hit", true);
        anim.SetBool("Freedom", true);
        base.ZeroLife();
    }

    public void SpawnParticles()
    {
        Instantiate(deathParticles, spawnParticlePoint.position, spawnParticlePoint.rotation);
        FindObjectOfType<AudioManager>().Play("DeathEnemy");
    }

    public override void TakeDamage(float amount)
    {
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        base.TakeDamage(amount);
    }
}
