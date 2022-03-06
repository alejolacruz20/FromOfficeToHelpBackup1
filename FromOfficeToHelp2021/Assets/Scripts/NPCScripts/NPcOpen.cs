using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: LACRUZ

public class NPcOpen : MonoBehaviour
{
    // NPC HACIA EL ELEVADOR 

    public Animator anim;
    public GameObject playerBlock;

    private void Start()
    {
        anim.SetBool("OpenDoor", false);
        anim = GetComponent<Animator>();
        playerBlock.SetActive(true);
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "NPC")
        {
            anim.SetBool("OpenDoor", true);
        }

        if (Blocked_Door.finalTaken == true)
        {
            playerBlock.SetActive(false);
            FindObjectOfType<AudioManager>().Play("ElevatorRingBell");
            anim.SetBool("OpenDoor", true);
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "NPC")
        {
            anim.SetBool("OpenDoor", false);
        }
    }
}
