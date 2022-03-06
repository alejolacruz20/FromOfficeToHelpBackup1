using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TPFINAL: LACRUZ

public class LockDoors : MonoBehaviour
{
    public int index;
    Action ActionsDoors;
    public Animator anim;
    public GameObject selfDoor;
    public GameObject playerBlock;

    public void ChangeDoorState() 
    {
        anim.SetBool("OpenDoor", true);
        //ActionsDoors = OpenDoor;
        FindObjectOfType<AudioManager>().Play("OpenDoor");
        if (selfDoor.CompareTag("LockedDoor"))
        {
            playerBlock.SetActive(false);
        }
    }

    public void OpenDoor() 
    {
        anim.SetBool("OpenDoor", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("OpenDoor", false);
    }

    private void Start()
    {
        anim.SetBool("OpenDoor", false);
        ActionsDoors = CloseDoor;
    }

    //void Update()
    //{
    //    ActionsDoors();
    //}
}
