using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    [SerializeField]
    public GameObject smokePiso;
    [SerializeField]
    public GameObject smokeSystem;

    public ControladorValvulas controladorValvulas;

    public void StopSmoke() 
    {
        if (controladorValvulas.smokeOut)
        {
            Destroy(smokePiso);
            Destroy(smokeSystem);

            //REPRODUCIR UN SONIDO 
        }
    }
}
  