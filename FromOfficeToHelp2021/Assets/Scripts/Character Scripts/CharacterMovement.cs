using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CREADOR: LUCAS OLIVARES

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody RB;
    public float baseSpeed = 12f;
    public float speed;
    public Vector3 MoveDirection;
    public Animator camaraAnimator;


    private void Start()
    {
        speed = baseSpeed;
        camaraAnimator.SetBool("ShakeCamera", false);
    }

    public void SpeedVariation(float amount) //Pedimos un valor para saber cuanta velocidad tenemos
    {
        if (amount > 0f)
        {
            speed -= baseSpeed * amount;
            camaraAnimator.SetBool("ShakeCamera", true);
        }
        else
        {
            speed = baseSpeed;
            camaraAnimator.SetBool("ShakeCamera", false);
        }
    }

    void Update()
    {
        float HorMov = Input.GetAxis("Horizontal");
        float VerMov = Input.GetAxis("Vertical");

        if (HorMov != 0 || VerMov != 0)
        {
            MoveDirection = transform.forward * VerMov + transform.right * HorMov;
            RB.velocity = MoveDirection * speed;
        }
    }
}



