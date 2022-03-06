using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: LACRUZ

public class NoteCounter : MonoBehaviour
{
    public static int noteCounterLevel1;

    private void OnTriggerStay(Collider target)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            noteCounterLevel1++;
            Destroy(this.gameObject);
        }
    }
}
