﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Alejo Lacruz
public class Blocked_Door : MonoBehaviour
{
    public Animator anim;
    public bool inside = false;
    bool door;
    public static bool taken = false;
    public static bool finalTaken = false;
    AudioManager audioManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        finalTaken = false;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Player")
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if(target.tag == "Player")
        {
            inside = false;
        }
    }

    public virtual void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E) && taken)
        {
            door = !door;
            audioManager.Play("UnlockDoor");
        }
        if (door)
        {
            anim.SetBool("abierta", true);
        }
        else
        {
            anim.SetBool("abierta", false);
        }

        if (inside && Input.GetKeyDown(KeyCode.E) && taken == false)
        {
            audioManager.Play("Blocked Door");
            anim.SetBool("abierta", false);
        }
    }  
}
