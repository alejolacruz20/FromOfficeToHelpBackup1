 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroEnergia : MonoBehaviour
{
    public static bool playerHaveTheLever;
    public static bool playerHaveTheConnector;
    public bool theLeverIsConnected;
    public bool theConnectorIsConnected;
    public Renderer[] cables;
    public GameObject lever;
    public int LeverOrientation = 0;
    public Animator PalancaInterruptor; 
    
    void Start()
    {
        lever.SetActive(false);
        playerHaveTheConnector = false;
        playerHaveTheLever = false;
        theConnectorIsConnected = false;
        theLeverIsConnected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (theConnectorIsConnected == true)
        {

            if (LeverOrientation == 0)
            { 
                cables[1].material.SetColor("_Color", Color.red);
                cables[LeverOrientation].material.SetColor("_Color", Color.green);
            }
            else if (LeverOrientation == 1)
            {
                cables[0].material.SetColor("_Color", Color.red);
                cables[LeverOrientation].material.SetColor("_Color", Color.green);
            }
        }
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            if (theConnectorIsConnected == false && playerHaveTheConnector == true && Input.GetKeyDown(KeyCode.E))
            {
                theConnectorIsConnected = true;
            }

            if (theLeverIsConnected == false && playerHaveTheLever == true && Input.GetKeyDown(KeyCode.E))
            {

                lever.SetActive(true);
                theLeverIsConnected = true;
            }
            else if (theLeverIsConnected == true && Input.GetKeyDown(KeyCode.E))
            {
                lever.SetActive(false);
                theLeverIsConnected = false;
            }
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("PlayerBullet"))
        {
            if (theLeverIsConnected == true)
            {
                PalancaInterruptor.SetBool("PrimerInterruptor", true);
                PalancaInterruptor.SetBool("SegundoInterruptor", true);
                LeverOrientation += 1;

                if (LeverOrientation > 1)
                {
                    PalancaInterruptor.SetBool("SegundoInterruptor", false);
                    LeverOrientation = 0;
                }
            }
        }
    }
}

