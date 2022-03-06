using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TPFINAL: ZEDDE, OLIVARES

public class TriggerWin : MonoBehaviour
{
    public KeycardLvL3 keycard;

    private void OnTriggerEnter(Collider other)
    {
        if (other && keycard.hasKey)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Victory");
        }
    }
}

