using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorValvulas : MonoBehaviour
{
    public GameObject[] levers;
    [SerializeField]
    public  List<int> values;
    [SerializeField]
    public bool smokeOut = false;
    public SmokeManager smokeManager;
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        // VERIFICAR QUE LAS PALANCAS ESTEN LA POSICION CORRECTA CON UN BOOL
    }
    
    void Update()
    {
        if (levers[0].GetComponent<Valvulas>().activado == true && levers[1].GetComponent<Valvulas>().activado == true && levers[2].GetComponent<Valvulas>().activado == true && levers[3].GetComponent<Valvulas>().activado == true)  //3142 - 3-5+7*2 = 12 <-- la secuencia y como se traducirÃ­a en la cuenta de verificacion 4132
        {
            if (values[0] - values[1] + values[2] * values[3] == 12)
            {
                print("Todo ok"); //El humo se detiene
                smokeOut = true;
                smokeManager.StopSmoke();
                //audioManager.Play("GasOut"); //Reproducimos el sonido 
            }
            else
            {
                levers[0].GetComponent<Valvulas>().activado = false;
                levers[1].GetComponent<Valvulas>().activado = false;
                levers[2].GetComponent<Valvulas>().activado = false;
                levers[3].GetComponent<Valvulas>().activado = false;

                values.Clear();
                print("Te equivocaste"); //Las palancas bajan todas juntas y se vuelve a probar
                
                levers[0].GetComponent<Animator>().SetBool("Character", false);
                levers[1].GetComponent<Animator>().SetBool("Character", false);
                levers[2].GetComponent<Animator>().SetBool("Character", false);
                levers[3].GetComponent<Animator>().SetBool("Character", false);

                levers[0].GetComponent<Animator>().SetBool("WrongCombination", true);
                levers[1].GetComponent<Animator>().SetBool("WrongCombination", true);
                levers[2].GetComponent<Animator>().SetBool("WrongCombination", true);
                levers[3].GetComponent<Animator>().SetBool("WrongCombination", true);
            }
        }
    }
}
