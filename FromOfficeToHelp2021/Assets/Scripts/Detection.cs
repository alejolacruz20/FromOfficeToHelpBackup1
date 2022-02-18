using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    string playerTag;
    Transform lente;
    
    void Start()
    {
        lente = transform.parent.GetComponent<Transform>();
        playerTag = GameObject.FindGameObjectWithTag("Player").tag;
    }

    
    void OntriggerStay(Collider col)
    {
        if (col.gameObject.tag == playerTag)
        {
            Vector3 direction = col.transform.position - lente.position;
            RaycastHit hit;

            if (Physics.Raycast(lente.transform.position, direction.normalized, out hit, 1000))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
