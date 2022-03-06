using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class SniperEnemy : MonoBehaviour
{
    public Transform playerPosition;
    public Transform shootingPoint;
    public GameObject bullet;
    public float chronometer;
    public float currentChronometer = 2;
    public bool throwing =  false;
    public Animator anim;
    public bool iSawThePlayer;
    public float moveChronometer;
    public float moveChronometerLimit = 2;
    public float speed = 2;

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("PlayerBullet"))
        {
            iSawThePlayer = true;
        }
    }

    void Update()
    {
        Apuntado();
    }

    public void Apuntado()
    {
        if(iSawThePlayer == false)
        {
            if (Vector3.Distance(playerPosition.transform.position, transform.position) < 10)
            {
                transform.LookAt(new Vector3(playerPosition.transform.position.x, transform.position.y, playerPosition.transform.position.z));
                shootingPoint.LookAt(new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, playerPosition.transform.position.z));

                if (throwing == false)
                {
                    throwing = true;
                    anim.SetBool("Throw", true);
                }

                iSawThePlayer = true;
            }
        }
        else
        {
            moveChronometer += Time.deltaTime;
            if (moveChronometer < moveChronometerLimit)
            {
                anim.SetBool("Throw", false);
                transform.LookAt(new Vector3(playerPosition.transform.position.x, transform.position.y, playerPosition.transform.position.z));
                transform.position += (transform.forward * speed * Time.deltaTime);
            }
            else if (moveChronometer >= moveChronometerLimit)
            {
                transform.LookAt(new Vector3(playerPosition.transform.position.x, transform.position.y, playerPosition.transform.position.z));
                shootingPoint.LookAt(new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, playerPosition.transform.position.z));
                if (throwing == false)
                {
                    throwing = true;
                    anim.SetBool("Throw", true);
                }
            }
        }
    }

    public void Throwing()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

    public void EndAnimation()
    {
        throwing = false;
        anim.SetBool("Throw", false);
        moveChronometer = 0;
    }

    public void RestartChronometer()
    {
        //Para que el chronometer del movimiento vuelva a 0 al final de la animacioon de disparo y vuelva a hacer la caminata
        moveChronometer = 0;
    }
}
