using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterHealth : GeneralEntitiesLife
{
    public Image healthBar;
    public GameObject defeatUI;
    public Animation anim;
    public Image mascaraDaño;

    private void Update()
    {
        float valorAlfa = 1f / baseHitPoints * (baseHitPoints - currentHitPoints);
        mascaraDaño.color = new Color(1, 1, 1, valorAlfa);
    }


    public override void TakeDamage(float amount)
    {
        //Ejecuta normalmente el TakeDamage, pero se le agrega la actualizacion de la barra de vida

        //base.TakeDamage(amount);
        //if (healthBar)
        //{
        //    healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
        //}
        base.TakeDamage(amount);
        currentHitPoints = Mathf.Clamp(currentHitPoints - amount, 0f, baseHitPoints);
        healthBar.transform.localScale = new Vector2(currentHitPoints / baseHitPoints, 1);
        FindObjectOfType<AudioManager>().Play("CharacterDMG");

    }

    public void Heal(float amount)
    {
        //Curacion del personaje

        if (amount > 0 && currentHitPoints < baseHitPoints)
        {
            currentHitPoints += amount;
            if (currentHitPoints > 0) //condición para no pasarnos del máximo
            {
                if (currentHitPoints > baseHitPoints)
                    currentHitPoints = baseHitPoints;
                currentHitPoints = Mathf.Clamp(currentHitPoints + amount, 0f, baseHitPoints);
                healthBar.transform.localScale = new Vector2(currentHitPoints / baseHitPoints, 1);
            }
        }
    }

    public override void ZeroLife()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Defeat");
        //Va a la pantalla de derrota
    }

}