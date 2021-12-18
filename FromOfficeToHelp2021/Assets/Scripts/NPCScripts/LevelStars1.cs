using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStars1 : MonoBehaviour
{
    public Animator starAnimLVL1;

    private void Start()
    {
        starAnimLVL1.SetBool("FirstStar", false);
        starAnimLVL1.SetBool("SecondStar", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(NPCWaypoints.npcCounterLevel1 >= 3 || NoteCounter.noteCounterLevel1 >= 1)
        {
            starAnimLVL1.SetBool("FirstStar", true);
            if(NPCWaypoints.npcCounterLevel1 >= 3 && NoteCounter.noteCounterLevel1 >= 1)
            {   
                starAnimLVL1.SetBool("SecondStar", true);
            }
        }
        else
        {
            starAnimLVL1.SetBool("FirstStar", false);
        }
    }
}
