using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Creador: Tiago Zedde
public class SceneChangerLevel2 : MonoBehaviour
{
    public Animator uiAnim;
    public string word;
    //public Transform myTransform;
    //public GameObject myPlayer;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            uiAnim.SetBool("Transition", true);
            Blocked_Door.taken = false;
            Blocked_Door.finalTaken = false;
            //victory = true;
            //myPlayer.transform.position = myTransform.transform.position;
            ChangesScene(word);
        }
    }

    public void ChangesScene(string word) //Cambiar de Escena
    {
        SceneManager.LoadScene(word);
    }
}