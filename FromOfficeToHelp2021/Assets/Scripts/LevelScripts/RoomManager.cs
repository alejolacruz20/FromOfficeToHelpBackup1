using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class RoomManager : MonoBehaviour
{
    public BoxWaypoints cajaActivated;
    public CentroEnergia moduloDeEnergia;
    public int moduloLever;

    void Start()
    {
        cajaActivated.enabled = false;
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
                    cajaActivated.enabled = true;
                    break;

                case 1:
                    cajaActivated.enabled = false;
                    break;
            }
        }
    }
}

