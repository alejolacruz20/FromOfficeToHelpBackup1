using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Creador: Tiago Zedde
public class SceneChanger : MonoBehaviour
{
    public bool victory = false;
    public Animator uiAnim;
    //public Transform myTransform;
    //public GameObject myPlayer;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            uiAnim.SetBool("Transition", true);
            //victory = true;
            //myPlayer.transform.position = myTransform.transform.position;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Victory");
        }
    }
    public void Exit() //Cerrar el juego
    {
        Application.Quit();
    }

    public void ChangesScene(string word) //Cambiar de Escena
    {
        SceneManager.LoadScene(word);
    }
}
