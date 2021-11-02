using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : GeneralEntitiesLife
{
    public GameObject victoryZone;
    public static bool downBoss = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }
    public override void ZeroLife()
    {
        downBoss = true;
        victoryZone.SetActive(true);
        base.ZeroLife();
        //YAY
    }
}
