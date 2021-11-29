using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public int totalKeys;
    public static bool[] keys;

    void Start()
    {
        keys = new bool[totalKeys];
    }
}
