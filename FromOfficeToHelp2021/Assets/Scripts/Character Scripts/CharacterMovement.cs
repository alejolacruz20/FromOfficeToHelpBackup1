using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CREADOR: LUCAS OLIVARES

public class CharacterMovement : MonoBehaviour
{
    CapsuleCollider Playercol;
    float OriginalHeight;
    public float ReducedHeigth;
    public Rigidbody RB;
    public float baseSpeed = 12f;
    public float speed;
    public Vector3 MoveDirection;
    public Animator camaraAnimator;


    private void Start()
    {
        Playercol = GetComponent<CapsuleCollider>();
        OriginalHeight = Playercol.height;
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GoUp();
        }
        
    }

    void Crouch() //Metodo para agacharse
    {
        Playercol.height = ReducedHeigth;
    }

    void GoUp() //Metodo para levantarse
    {
        Playercol.height = OriginalHeight;
    }
}



