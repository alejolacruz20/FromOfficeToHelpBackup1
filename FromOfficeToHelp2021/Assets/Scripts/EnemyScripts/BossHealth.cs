using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : GeneralEntitiesLife
{
    public GameObject victoryZone;
    public Animator anim;
    public static bool downBoss = false;
    public Transform spawnPDamagePArticles;
    public ParticleSystem damageParticles;

    public override void TakeDamage(float amount)
    {
        Instantiate(damageParticles, spawnPDamagePArticles.position, spawnPDamagePArticles.rotation);
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        base.TakeDamage(amount);
    }
    public override void ZeroLife()
    {
        downBoss = true;
        victoryZone.SetActive(true);
        anim.SetBool("Defeat", true);
        base.ZeroLife();
        //YAY
    }
}
