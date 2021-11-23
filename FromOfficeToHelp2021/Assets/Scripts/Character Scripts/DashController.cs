using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Lucas Olivares y Tiago Zedde
public class DashController : MonoBehaviour
{
    CharacterMovement MoveScript;
    public float DashSpeed;
    public float DashTime;
    public float dash_Timer;
    public float current_dashTimer;
    public bool canDash;
    public Animator anim;
    AudioManager AudioManager;

    void Start()
    {
        MoveScript = GetComponent<CharacterMovement>();
        anim.SetBool("Dash", false);
        AudioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dash_Timer += Time.deltaTime;
        if (dash_Timer > current_dashTimer) //Controla el tiempo para saber si podemos dashear
        {
            canDash = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        if (canDash) //Preguntamos si está dentro del tiempo para dashear
        {
            canDash = false;
            dash_Timer = 0f;
            float StartTime = Time.time;
            anim.SetBool("Dash", true);
            AudioManager.Play("Dash"); //Reproducimos el sonido
            MoveScript.speed *= DashSpeed; //Movimiento del dash
            yield return new WaitForSeconds(DashTime);
            MoveScript.speed /= DashSpeed; //Movimiento del dash
            anim.SetBool("Dash", false);
        }
    }
}
