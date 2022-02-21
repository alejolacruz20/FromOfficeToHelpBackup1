using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamara : MonoBehaviour
{
    //CREADOR: LUCAS OLIVARES

    Transform camCuerpo;
    bool startNextRot = true;
    public bool rotRight;
    public float yaw;          //valor para el angulo de rotacion. 
    public float pitch;        //Valor para al angulo vertical de la camara.
    public float secondsToRot; //Tiempo que toma en hacer una rotacion.
    public float rotSwitchTime;//Tiempo de espera una vez hecho una rotacion para iniciar la siguiente.
 
    void Start()
    {
        camCuerpo = transform.GetChild(0);
        camCuerpo.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
        SetUpStartRotation();
    }

    void Update()
    {
        //AQUI AMBAS LINEAS FUNCIONAN COMO UN LOOP VA A LA IZQUIERDA CON EL PRIMER "IF", LUEGO VUELVE CON EL SEGUNNDO "ELSE IF"

        if (startNextRot && rotRight)
        {
            StartCoroutine(Rotate(yaw,secondsToRot)); //Funcion que inicia la rotacion 
        }
        else if (startNextRot && !rotRight)
        {
            StartCoroutine(Rotate(-yaw, secondsToRot)); //Funcion que inicia la regresion de la rotacion 
        }
    }

    IEnumerator Rotate(float yaw, float duration) //Co-rutina que dispara el movimento de la camara 
    {
        startNextRot = false;

        Quaternion initialRotation = transform.rotation;

        float timer = 0; 

        while (timer < duration) //La velocidad con la que genera una rotaacion dependera del tiempo dentro del codigo
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * yaw, Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(rotSwitchTime); //Tiempo que espera para volver a rotar 

        startNextRot = true;
        rotRight = !rotRight;
    }
    void SetUpStartRotation() 
    {
        if (rotRight)
        {
            transform.localRotation = Quaternion.AngleAxis(-yaw / 2, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(yaw / 2, Vector3.up);
        }
    }
}
