using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Creador: Federico Paradiso
public class NotesAppear : MonoBehaviour
{
    public bool paperOnFace; 
    public string buttonName = "Interact";
    public Collider cartelCollider;
    [SerializeField]
    private Image _cartel;
    [SerializeField]
    private Image _backgroundCartel;
    [SerializeField]
    private Text _pulseE;

    private void Start()
    {
        paperOnFace = false;
        _pulseE.enabled = false;
}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pulseE.enabled = true;
        }

        if (Input.GetButtonDown(buttonName) && paperOnFace == false)
        {
            cartelCollider.enabled = false;
            _cartel.enabled = true;
            _backgroundCartel.enabled = true;
            paperOnFace = true;
        }
        else if(Input.GetButtonDown(buttonName) && paperOnFace == true)
        {
            cartelCollider.enabled = true;
            _cartel.enabled = false;
            _backgroundCartel.enabled = false;
            paperOnFace = false;
        }

    }


    
    private void OnTriggerExit(Collider other)
    {
        _pulseE.enabled = false;

        if (other.CompareTag("Player"))
        {
            cartelCollider.enabled = true;
            _cartel.enabled = false;
            _backgroundCartel.enabled = false;
            paperOnFace = false;
        }
    }
}
