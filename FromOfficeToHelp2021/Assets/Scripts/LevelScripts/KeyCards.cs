using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI, ZEDDE, OLIVARES


public class KeyCards : MonoBehaviour, IgeneralPickUp
{
    public int index;

    public void Actions() 
    {
        KeyInventory.keys[index] = true;
        Destroy(this.gameObject);
    }
}
