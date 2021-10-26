using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CREADOR: LUCAS OLIVARES

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        MoveDirection = transform.right * x + transform.forward * z; //Movimiento en base a la direccion de la camara
        controller.Move(MoveDirection * speed * Time.deltaTime);

    }
}



