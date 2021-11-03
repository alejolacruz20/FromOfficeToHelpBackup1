using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPcOpen : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.SetBool("Open", false);
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "NPC")
        {
            anim.SetBool("Open", true);
        }

        if (Blocked_Door.finalTaken == true && Blocked_Door.taken == true)
        {
            FindObjectOfType<AudioManager>().Play("ElevatorRingBell");
            anim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "NPC")
        {
            anim.SetBool("Open", false);
        }
    }
}
