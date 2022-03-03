using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardLvL3 : MonoBehaviour
{
    [SerializeField]
    public bool hasKey = false;
    [SerializeField]
    public MeshRenderer Keycard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            hasKey = true;
            Keycard.enabled = false;
        }
    }
}
