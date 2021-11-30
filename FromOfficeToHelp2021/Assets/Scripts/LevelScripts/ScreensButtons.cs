using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensButtons : MonoBehaviour
{
    public bool activated;
    public bool analyzed;
    public Renderer crazyRend;
    public Renderer happyRend;

    void Start()
    {
        crazyRend.enabled = true;
        happyRend.enabled = false;
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.CompareTag("PlayerBullet"))
        {
            activated = true;
            crazyRend.enabled = false;
            happyRend.enabled = true;
        }
    }
}
