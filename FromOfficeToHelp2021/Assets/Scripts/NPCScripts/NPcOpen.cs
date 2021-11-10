using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPcOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject playerblock;

    private void Start()
    {
        playerblock.SetActive(true);
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
            playerblock.SetActive(false);
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
