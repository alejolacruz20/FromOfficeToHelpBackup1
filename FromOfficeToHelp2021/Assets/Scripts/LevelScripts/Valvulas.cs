using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class Valvulas : MonoBehaviour
{
    [SerializeField]
    public ControladorValvulas controlador;
    public float valores;
    public bool activado;
    [SerializeField]
    public Animator animator;
    public bool ValueGiven;

    private void OnTriggerStay(Collider target)
    {
        if (ValueGiven == false)
        {
            if (target.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                controlador.values.Add(valores);
                ValueGiven = true;
                activado = true;
                animator.SetBool("Character", true);
                animator.SetBool("WrongCombination", false);

                FindObjectOfType<AudioManager>().Play("GasOut");
            }
        }
    }
}
