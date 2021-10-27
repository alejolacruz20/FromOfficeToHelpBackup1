using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Tiago Zedde
public class PowerUpGeneral : MonoBehaviour
{
    public CharacterHealth life;
    public float healingAmount;
    public GameObject target;
    public CharacterAnimationInteraction characterShooting;


    public void OnTriggerEnter(Collider target)
    {
        //HealthUp();
        //Destroy(gameObject);
        if (target.CompareTag("Player"))
        {
            if (life != null)
            {
                HealthUp();
            }
            else if (characterShooting != null)
            {
                SpeedShoot();
            }

            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(gameObject);
        }

    }

    public void Start()
    {
        //CharacterHealth healthbar = target.GetComponent<CharacterHealth>();
        //life = healthbar;
    }

    public void SpeedShoot()
    {
        characterShooting.speedShooting = true;
    }

    public void HealthUp()
    {
        //life.SendMessage("Heal", healingAmount);
        life.Heal(healingAmount);
    }

}
