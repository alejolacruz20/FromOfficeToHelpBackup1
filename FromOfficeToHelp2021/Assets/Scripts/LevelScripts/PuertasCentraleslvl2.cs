using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class PuertasCentraleslvl2 : MonoBehaviour
{
    public CentroEnergia centroDeEnergia;
    public int roomNumber;
    public Animator puertaCentral;
    //public Renderer door;
    
    public bool puertaAbierta;

    private void Start()
    {
        puertaCentral.SetBool("Open", false);
    }

    void Update()
    {
        if (centroDeEnergia.theConnectorIsConnected == true)
        {
            if (centroDeEnergia.LeverOrientation == roomNumber)
            {
                //door.enabled = false;
                puertaAbierta = true;
                puertaCentral.SetBool("Open", true);
            }
            else 
            {
                //door.enabled = true;
                puertaAbierta = false;
                puertaCentral.SetBool("Open", false);
            }
        }
    }
}
