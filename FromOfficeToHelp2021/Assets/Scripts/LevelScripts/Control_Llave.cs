using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Alejo Lacruz
public class Control_Llave : MonoBehaviour
{
    public bool inside;
    public Renderer rend;
    AudioManager AudioManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
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
        if(inside)
        {
            Blocked_Door.taken = true;
            AudioManager.Play("Pickup");
            rend.gameObject.SetActive(false);
        }
    }
}
