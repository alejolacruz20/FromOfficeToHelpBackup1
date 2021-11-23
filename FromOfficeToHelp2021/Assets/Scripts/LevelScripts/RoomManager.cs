using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public BoxWaypoints cajaActivated;
    //public Charco charcoActivated;
    //public DisparoHorizontal disparosActivated;
    public CentroEnergia moduloDeEnergia;
    public int moduloLever;

    void Start()
    {
        //disparosActivated.enabled = false;
        cajaActivated.enabled = false;
        //charcoActivated.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moduloLever = moduloDeEnergia.LeverOrientation;

        if (moduloDeEnergia.theConnectorIsConnected == true)
        {
            switch (moduloLever)
            {
                case 0:
                    //disparosActivated.enabled = false;
                    cajaActivated.enabled = true;
                    //charcoActivated.enabled = false;
                    break;

                case 1:
                    cajaActivated.enabled = false;
                    //disparosActivated.enabled = true;
                   // charcoActivated.enabled = false;
                    break;

                //case 2:
                //   // charcoActivated.enabled = true;
                //    disparosActivated.enabled = false;
                //    cajaActivated.enabled = false;
                //    break;
            }
        }
    }
}

