using System.Collections;
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
    AudioManager AudioManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        finalTaken = false;
        AudioManager = FindObjectOfType<AudioManager>();
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
            AudioManager.Play("UnlockDoor");
        }
        if (door)
        {
            anim.SetBool("OpenDoor", true);
        }
        else
        {
            anim.SetBool("OpenDoor", false);
        }

        if (inside && Input.GetKeyDown(KeyCode.E) && taken == false)
        {
            AudioManager.Play("Blocked Door");
            anim.SetBool("OpenDoor", false);
        }
    }  
}
