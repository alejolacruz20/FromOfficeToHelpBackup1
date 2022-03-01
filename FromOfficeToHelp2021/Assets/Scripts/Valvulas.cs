using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valvulas : MonoBehaviour
{
    [SerializeField]
    public ControladorValvulas controlador;
    public int valores;
    public bool activado;
    [SerializeField]
    public Animator anime;

    private void OnTriggerStay(Collider target)
    {
        if (target.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            controlador.values.Add(valores);
            activado = true;
        }
    }
}
