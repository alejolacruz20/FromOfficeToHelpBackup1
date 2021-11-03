using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : GeneralEntitiesLife
{
    public GameObject victoryZone;
    public Animator anim;
    public static bool downBoss = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        FindObjectOfType<AudioManager>().Play("EnemyHit");
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
