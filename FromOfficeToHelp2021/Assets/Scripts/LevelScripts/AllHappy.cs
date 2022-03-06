using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllHappy : MonoBehaviour
{
    //TPFINAL: CERIANI, LACRUZ

    public Animator[] npcAnim;
    public ActivatedScreens activatedScreens;
 
    void Start()
    {
        activatedScreens.onActivatedScreens += OnHappiness; 
    }

    public void OnHappiness()
    {
        for (int j = 0; j < npcAnim.Length; j++)
        {
            npcAnim[j].SetBool("Happy", true);
        }
    }
}


