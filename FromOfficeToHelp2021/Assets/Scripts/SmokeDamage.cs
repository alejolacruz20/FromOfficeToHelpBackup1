using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamage : MonoBehaviour
{
    public float dañoAmount; // Daño que hace cada segundo
    public float chronometer;
    public float limitChronometer; // limite del cronometro
    public CharacterHealth vidaPlayer; // Script de vida del jugador
    bool activacion; // Activacion del daño, sería cuendo aparece el humo
    public float levelChronometer;
    public float limitLevelChonometer;

    void Start()
    {
        activacion = false;
    }

    void Update()
    {
        levelChronometer += Time.deltaTime;
        chronometer += 1 * Time.deltaTime;

        if (chronometer >= limitChronometer) //DAÑO POR SEGUNDO 
        {
            vidaPlayer.TakeDamage(dañoAmount);
            chronometer = 0;
        }

        if (levelChronometer >= limitLevelChonometer) //TIEMPO LIMITE DE NIVEL 
        {
            if (activacion == true)
            {
                dañoAmount = 100;
            }
        }
    }
}
