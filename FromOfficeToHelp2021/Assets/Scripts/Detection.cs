using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    //CREADOR: LUCAS OLIVARES

    string playerTag;
    Transform lens;
    
    void Start() //Indicamos la posicion del lente(lens) dentro del mundo y pedmos que busque el objeto con el tag de "Player".
    {
        lens = transform.parent.GetComponent<Transform>();
        playerTag = GameObject.FindGameObjectWithTag("Player").tag;
        Debug.Log("GameObject Encontrado " + GameObject.FindGameObjectWithTag("Player")); // Este debug es para encontrar al jugaodor.
    }


    void OnTriggerStay(Collider col) //En esta parte por alguna razon al colisionar con el player el raycast no lo detecta, quizas por mi poca experiencia usando Raycast, no estoy seguro.
    {
        if (col.gameObject.tag == playerTag)
        {
            Vector3 direction = col.transform.position - lens.position;
            RaycastHit hit;
            Debug.DrawLine(lens.transform.position, direction.normalized, Color.green);// Aqui intene que el raycast sea visible pero falle en el intento.

            if (Physics.Raycast(lens.transform.position, direction.normalized, out hit, 1000)) //Posicion y longitud de salida del raycast.
            {
                Debug.Log(hit.collider.name); //Si choca con el player deberia de enviar un mensaje a la consola. 
            }
        }
    }
}
