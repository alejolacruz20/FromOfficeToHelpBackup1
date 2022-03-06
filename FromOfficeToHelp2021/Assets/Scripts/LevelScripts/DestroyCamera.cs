using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: ZEDDE,OLIVARES


public class DestroyCamera : MonoBehaviour
{
    public GameObject Detector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Detector.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
