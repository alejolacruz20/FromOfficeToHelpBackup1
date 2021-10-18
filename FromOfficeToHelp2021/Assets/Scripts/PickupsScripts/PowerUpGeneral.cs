using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Tiago Zedde
public class PowerUpGeneral : MonoBehaviour
{
    public CharacterHealth life;
    public float healingAmount;
    public GameObject target;


    public void OnTriggerEnter(Collider target)
    {
        HealthUp();
        Destroy(gameObject);
    }

    public void Start()
    {
        CharacterHealth healthbar = target.GetComponent<CharacterHealth>();
        life = healthbar;
    }
    public void HealthUp()
    {
        //life.SendMessage("Heal", healingAmount);
        life.Heal(healingAmount);
    }

}
