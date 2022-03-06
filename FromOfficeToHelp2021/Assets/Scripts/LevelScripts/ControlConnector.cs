using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class ControlConnector : MonoBehaviour, IgeneralPickUp
{

    public void Actions() 
    {
        CentroEnergia.playerHaveTheConnector = true;
        Destroy(this.gameObject);
    } 

  

}
