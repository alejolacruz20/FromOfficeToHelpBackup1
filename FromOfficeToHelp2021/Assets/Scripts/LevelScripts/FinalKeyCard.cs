using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyCard : Control_Llave
{
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Blocked_Door.finalTaken = true;
    }
}
