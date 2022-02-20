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
        //Debug.Log("GameObject Encontrado " + GameObject.FindGameObjectWithTag("Player"));
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == playerTag)
        {
            Vector3 direction = col.transform.position - lens.position;
            RaycastHit hit;
            Debug.DrawRay(lens.transform.position, direction.normalized, Color.red, 20f);

            if (Physics.Raycast(lens.transform.position, direction.normalized, out hit, 1000f))
            {
                Debug.Log(col.gameObject.name);
            }
        }
    }
}
