using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCamera : MonoBehaviour
{
    public GameObject Detector;

    //private void OnriggerEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("PlayerBullet"))
    //    {
    //        Detector.SetActive(false);
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Detector.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
