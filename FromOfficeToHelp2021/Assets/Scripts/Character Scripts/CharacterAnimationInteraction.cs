using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Alejo Lacruz
public class CharacterAnimationInteraction : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] bulletSpawner;
    public int currentHappyPoints;
    //public string buttonName = "Fire 1";
    public bool doingTheAnimation;
    public Animator characterAnimator;
    public float currentCronometer;
    public float cronometer = 1.5f;
    public bool speedShooting;
    public float speedShootingChronometer;
    public float speedShootingChronometerLimit = 2f;
    public bool startSpeedShootingChronometer;
    AudioManager AudioManager;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        doingTheAnimation = false;
        AudioManager = FindObjectOfType<AudioManager>();
    }

    private void FixedUpdate()
    {
        cronometer += Time.deltaTime; //Tomamos como referencia para el enfriamiento
        InputCharacter();

        if (Input.GetKeyDown(KeyCode.E) && doingTheAnimation == false)
        {
            doingTheAnimation = true;
            characterAnimator.SetBool("Interact", true); //PIDE LA TECLA E Y PONE LA ANIMACIÓN DE INTERACT EN TRUE
        }

        if (Input.GetKeyDown(KeyCode.Q) && doingTheAnimation == false)
        {
            doingTheAnimation = true;
            characterAnimator.SetBool("Defense", true); //PIDE LA TECLA Q Y PONE LA ANIMACION DE DEFENSE EN TRUE
        }

        if (speedShooting == true)
        {
            speedShootingChronometer += Time.deltaTime;
            if (speedShootingChronometer >= speedShootingChronometerLimit)
            {
                characterAnimator.SetBool("SpeedShoot", false);
                speedShooting = false;
                speedShootingChronometer = 0;
            }
        }
    }

    public void Defensefinished() //Funcion para ponerlo en falso
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Defense", false);
    }

    public void InteractionFinished() //Funcion para ponerlo en falso
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Interact", false);
    }

    public void InputCharacter()
    {
        if (speedShooting == false)
        {
            if (currentCronometer <= cronometer) //Enfriamiento
            {
                doingTheAnimation = false;
                characterAnimator.SetBool("Attack", false);

                if (Input.GetKeyDown(KeyCode.Mouse0) && doingTheAnimation == false) // Dentro del Update llamar a esta funcion 
                {
                    doingTheAnimation = true;
                    characterAnimator.SetBool("Attack", true);
                    cronometer = 0f;
                }
            }
        }
        else
        {
            characterAnimator.SetBool("SpeedShoot", false);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Hacer animacion de levantar el brazo, que cuando termina pasa a brazo extendido
                characterAnimator.SetBool("SpeedShoot", true);
                AudioManager.Play("Shoot"); //Sonido Automatico
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                characterAnimator.SetBool("SpeedShoot", true);
          
                for (int i = 0; i < bulletSpawner.Length; i++)
                {
                    Instantiate(bullet, bulletSpawner[i].position, bulletSpawner[i].rotation);
                }
                //hacer animacion de disparo rapido
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //vuelve a idle
                characterAnimator.SetBool("SpeedShoot", false);
            }
        }
    }

    public void AnimationShooting()
    {
        AudioManager.Play("Shoot");
        for (int i = 0; i < bulletSpawner.Length; i++)
        {
            Instantiate(bullet, bulletSpawner[i].position, bulletSpawner[i].rotation); //Instanciamos una bala
        }
    }
}
