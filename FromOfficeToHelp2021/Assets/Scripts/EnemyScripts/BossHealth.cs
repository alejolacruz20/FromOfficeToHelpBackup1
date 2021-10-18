using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : GeneralEntitiesLife
{
    public GameObject victoryZone;
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }
    public override void ZeroLife()
    {
        base.ZeroLife();
        victoryZone.SetActive(true);
        //YAY
    }
}
