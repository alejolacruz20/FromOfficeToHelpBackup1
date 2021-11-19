using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasCentraleslvl2 : MonoBehaviour
{
    public CentroEnergia centroDeEnergia;
    public int roomNumber;
    public Renderer door;
    
    public bool puertaAbierta;
   

    // Update is called once per frame
    void Update()
    {
        if (centroDeEnergia.theConnectorIsConnected == true)
        {
            if (centroDeEnergia.LeverOrientation == roomNumber)
            {
                door.enabled = false;
                puertaAbierta = true;
            }
            else 
            {
                door.enabled = true;
                puertaAbierta = false;
            }
        }
    }
}
