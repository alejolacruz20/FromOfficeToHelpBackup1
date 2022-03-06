using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: ZEDDE, CERIANI

public class KeyInventory : MonoBehaviour
{
    public int totalKeys;
    public static bool[] keys;

    void Start()
    {
        keys = new bool[totalKeys];
    }
}
