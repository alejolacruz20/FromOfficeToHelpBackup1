using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCards : MonoBehaviour, IgeneralPickUp
{
    public int index;

    public void Actions() 
    {
        KeyInventory.keys[index] = true;
        Destroy(this.gameObject);
    }
}
