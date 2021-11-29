using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    // ESTE SCRIPT ABRE LA PUERTA DEL JUGADOR AL INICIAR EL NIVEL 

    public Animator anim;

    private void Start()
    {
        anim.SetBool("OpenDoor", true);
        anim = GetComponent<Animator>();
    }
}
