using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.SetBool("Open", true);
        anim = GetComponent<Animator>();
    }
}
