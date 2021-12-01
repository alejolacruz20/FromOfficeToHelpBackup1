using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedScreens : MonoBehaviour
{
    public GameObject[] screens;
    ScreensButtons activatedScreens;
    public List<GameObject> activatedScreensList;
    public Animator[] npcAnim;
    public Transform[] happyPointsSpawner;
    public Renderer anotadorFinal;
    public GameObject anotadorFinalObject;
    public GameObject happyParticles;
    public AudioSource audioclipHappiness;
    bool dontSpawn = false;

    void Start()
    {
        //anotadorFinal.enabled = false;
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
            //anotadorFinal.enabled = true;
            anotadorFinalObject.SetActive(true);

            for (int j = 0; j < npcAnim.Length; j++)
            {
                npcAnim[j].SetBool("Happy", true);
            }

            if (!dontSpawn)
            {
                for (int k = 0; k < happyPointsSpawner.Length; k++)
                {
                    Instantiate(happyParticles, happyPointsSpawner[k].transform.position, happyPointsSpawner[k].transform.rotation);
                    audioclipHappiness.Play();

                    if (k == happyPointsSpawner.Length - 1)
                    {
                        dontSpawn = true;
                    }
                }
            }
        }
    }
}
