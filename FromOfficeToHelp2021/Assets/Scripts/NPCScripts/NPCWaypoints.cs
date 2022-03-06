using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL: CERIANI

public class NPCWaypoints : Waypoints
{
    public bool isHappy;
    public bool startChronometer;
    public bool animationEnds;
    public float chronometer;
    public float limitChronometer;
    public int happyPoints;
    public static int npcCounterLevel1;
    CharacterAnimationInteraction targetPoints;
    public Transform spawnParticlesHeart;
    public ParticleSystem heartparticles;

    public void Start()
    {
        _waypointIndex = 0;
        targetPoints = playerTarget.GetComponent<CharacterAnimationInteraction>();
        npcCounterLevel1 = 0;
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "PlayerBullet")
        {
            isHappy = true;
            Instantiate(heartparticles, spawnParticlesHeart.position, spawnParticlesHeart.rotation);
            FindObjectOfType<AudioManager>().Play("Thank You");
            npcCounterLevel1++;
            anim.SetBool("Happy", true);
            Debug.Log("Has liberado a " + happyPoints + " colegas.");
        }    
    }

    public override void Update()
    {
        if(isHappy == true && animationEnds == true)
        {
            transform.LookAt(waypoints[_waypointIndex].position);
            transform.Translate(new Vector3(0, 0, 2 * Time.deltaTime));
            base.Update();
        }
    }

    public override void EndAnimation()
    {
        animationEnds = true;
    }

    public override void IsFighting()
    {
    }

    public override void IsWalking()
    {
    }

    public override void MaxIndex()
    {
        Destroy(this.gameObject);
    }
}
    

