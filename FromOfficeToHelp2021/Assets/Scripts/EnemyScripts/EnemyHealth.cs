using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GeneralEntitiesLife
{
    public Animator anim;
    public RandomMovement randomMovement;
    public Waypoints waypointsMovement;

    public override void ZeroLife()
    {
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

        anim.SetBool("Freedom", true);
        base.ZeroLife();
    }
}
