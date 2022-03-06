using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivatedScreens : MonoBehaviour
{
    //TPFINAL: CERIANI, LACRUZ

    public GameObject[] screens;
    ScreensButtons activatedScreens;
    public List<GameObject> activatedScreensList;
    public GameObject anotadorFinalObject;
    public event Action onActivatedScreens;

    void Start()
    {
        anotadorFinalObject.SetActive(false);
    }

    void Update()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            activatedScreens = screens[i].GetComponent<ScreensButtons>();

            if (activatedScreens.analyzed == false)
            {

                if (activatedScreens.activated == true)
                {
                    activatedScreensList.Add(screens[i]);
                    activatedScreens.analyzed = true;
                }
            }
        }

        if (screens.Length == activatedScreensList.Count && anotadorFinalObject != null)
        {
            onActivatedScreens?.Invoke(); 
            anotadorFinalObject.SetActive(true);
        }
    }
}
