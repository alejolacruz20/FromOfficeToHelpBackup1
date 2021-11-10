﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPcOpen : MonoBehaviour
{
    public Animator anim;
    public GameObject playerBlock;

    private void Start()
    {
        anim.SetBool("Open", false);
        anim = GetComponent<Animator>();
        playerBlock.SetActive(true);
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "NPC")
        {
            anim.SetBool("Open", true);
        }

        if (Blocked_Door.finalTaken == true && Blocked_Door.taken == true)
        {
            playerBlock.SetActive(false);
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
