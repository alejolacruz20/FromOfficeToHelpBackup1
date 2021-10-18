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
            Destroy(this.gameObject);
        else if (mywaypoints != null)
            Destroy(this.gameObject);
        base.ZeroLife();
    }

}
