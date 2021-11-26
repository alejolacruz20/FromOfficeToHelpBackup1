using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Alejo Lacruz
public class ControlDoor : MonoBehaviour
{
    Animator anim;
    bool Dentro = false;
    bool puerta;
    AudioManager AudioManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        AudioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            Dentro = false;
        }

        if (col.tag == "NPC")
        {
            anim.SetBool("OpenDoor", false);
            AudioManager.Play("OpenDoor");
        }
    }

    void OnTriggerEnter(Collider col)
    {
       if(col.tag == "Player")
       {
           Dentro = true;
       }

       if(col.tag == "NPC")
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

    private void Update()
    {
        if(Dentro && Input.GetKeyDown(KeyCode.E))
        {
            puerta = !puerta;
            AudioManager.Play("OpenDoor");
        }
        if(puerta)
        {
            anim.SetBool("OpenDoor", true);
        }
        else
        {
            anim.SetBool("OpenDoor", false);
        }
    }
}
