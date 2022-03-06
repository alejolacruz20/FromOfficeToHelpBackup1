using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: PARADISO

public class EffectObject : MonoBehaviour
{
    public float time;

    private void Start()
    {
        Destroy(gameObject, time);
    }


}
