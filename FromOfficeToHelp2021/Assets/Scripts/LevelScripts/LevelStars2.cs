using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStars2 : MonoBehaviour
{
    public Animator starAnimLVL2;

    private void Start()
    {
        starAnimLVL2.SetBool("FirstStar", false);
        starAnimLVL2.SetBool("SecondStar", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCWaypoints.npcCounterLevel1 >= 3 || NoteCounter.noteCounterLevel1 >= 2)
        {
            starAnimLVL2.SetBool("FirstStar", true);
            if (NPCWaypoints.npcCounterLevel1 >= 3 && NoteCounter.noteCounterLevel1 >= 2)
            {
                starAnimLVL2.SetBool("SecondStar", true);
            }
        }
        else
        {
            starAnimLVL2.SetBool("FirstStar", false);
        }
    }
}
