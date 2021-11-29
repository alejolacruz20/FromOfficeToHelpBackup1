using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Creador: Alejo Lacruz
public class ControlDoor : MonoBehaviour
{
  //PUERTA BASE 
    Action Door;
    Animator anim;
    bool puerta;
    AudioManager AudioManager;
    public static bool taken = false;
    //public bool finalTaken = false;
    public GameObject selfDoor;
    public bool lockDoorIsOpen;

    void Start()
    {
        anim = GetComponent<Animator>();
        AudioManager = FindObjectOfType<AudioManager>();
        Door = DoorClosed;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "NPC")
        {
            anim.SetBool("OpenDoor", false);
            AudioManager.Play("OpenDoor");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "NPC")
        {
            puerta = !puerta;
            AudioManager.Play("OpenDoor");

            if (puerta)
            {
                anim.SetBool("OpenDoor", true);
            }
            else
            {
                anim.SetBool("OpenDoor", false);
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (selfDoor.CompareTag("LockedDoor"))
            {
                if (Input.GetKeyDown(KeyCode.E) && taken)
                {
                    lockDoorIsOpen = true;
                    taken = false;
                    AudioManager.Play("UnlockDoor");
                    Door = DoorOpen;
                }
                else
                {
                    if (!lockDoorIsOpen)
                    {
                        AudioManager.Play("Blocked Door");
                    }
                    
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    AudioManager.Play("OpenDoor");
                    Door = DoorOpen;
                }
            }   
        }
    }

    private void Update()
    {
        Door();
    }

    void DoorOpen()
    {
        anim.SetBool("OpenDoor", true);
    }

    void DoorClosed()
    {
        anim.SetBool("OpenDoor", false);
    }

    //ME GUSTA EL PAN UWU
}
