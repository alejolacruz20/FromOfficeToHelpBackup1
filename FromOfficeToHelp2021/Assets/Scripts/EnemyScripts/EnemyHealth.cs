using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GeneralEntitiesLife
{
    public Animator anim;
    public RandomMovement randomMovement;
    public Waypoints mywaypoints;
    public override void ZeroLife()
    {
        if (randomMovement != null)
        {
            anim.SetBool("Freedom", true);
            base.Death();
        }
        else if (mywaypoints != null)
        {
            anim.SetBool("Freedom", true);
            base.Death();
        }
    }
}
