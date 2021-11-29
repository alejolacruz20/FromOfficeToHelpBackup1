using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//Creador: Tiago Zedde
public class PowerUpHealing : MonoBehaviour, IgeneralPickUp
{
    public CharacterHealth life;
    public float healingAmount;
    public GameObject target;

    public void Actions()
    {
        life.Heal(healingAmount);
        Destroy(this.gameObject);
    }
}
