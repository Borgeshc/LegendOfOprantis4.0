using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

    //public Transform[] path;
    public Transform player;
    public Transform obj;
    public bool lookAtPlayer, stopFly, flyDown = true, flyDown2, fire, IsChasing;

    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

    float timeOfFire;
    public float dist2;
    float dist;
    Vector3 direction;

    public ParticleSystem fireParticles;

    private Animator animation;


    void Start () {
        lookAtPlayer = true;
        flyDown = true;
        fire = false;
        IsChasing = false;
        animation = GetComponent<Animator>();

        Fire(false);

    }

    // Update is called once per frame
    void Update () {
        dist = Vector3.Distance(obj.position, transform.position);

      
        direction = player.transform.position - this.transform.position;
        if (flyDown)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, obj.position, Time.deltaTime * speed);

            
        }


        
        if (lookAtPlayer)
        {
         this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
              Quaternion.LookRotation(direction), 0.1f);
        } 
        else
        {
            lookAtPlayer = false;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction - Vector3.right * 90), 0.1f);
            this.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }

        if (dist < 50)
        {
            fire = true;

        }

        if (fire == true)
        {

            Fire(true);

        }
        else
        {
            Fire(false);
        }

            Debug.Log(dist);

        if(dist < 10)
        {

            flyDown2 = true;

            flyDown = false;
        }
        Debug.Log(dist2);

        if(flyDown2 == true)
        {

            fire = false;

            Fire(false);

            //fireParticles.Stop();

            dist2 = Vector3.Distance(obj.position, transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
              Quaternion.LookRotation(direction - Vector3.right * 20), 0.1f);
            this.transform.Translate(Vector3.forward * 15 * Time.deltaTime);
        }

        if (dist2 > 24)
        {
            stopFly = true;

        }

        if(stopFly == true)
        {
            timeOfFire += Time.deltaTime;

            fire = false;

            flyDown2 = false;

            this.transform.Translate(Vector3.forward * 0 * Time.deltaTime);

            animation.SetBool("IsLanding", true);

            animation.SetBool("Roar", true);

            Debug.Log(timeOfFire);

            if(timeOfFire > 4.5f)
            {
                dist2 = Vector3.Distance(obj.position, transform.position);

                fire = false;

                //fireParticles.Stop();


                animation.SetBool("IdleFloor", true);
                Fire(false);
                Walking(true);

              

                if (dist2 < 19)
                {

                    Fire(false);
                    Walking(false);
                    timeOfFire = 0;
                    fire = false;
                    
                }

            }

        }


    }

   public void Walking(bool chase)
    {
        if (chase == true)
        {

            fireParticles.Stop();
            this.transform.Translate(Vector3.forward * 7 * Time.deltaTime);
            animation.SetBool("isWalking", true);
        }
        else
        {
            this.transform.Translate(Vector3.forward * 0 * Time.deltaTime);
            fireParticles.Stop();
            animation.SetBool("isWalking", false);
            fire = false;
        }
    }

    void Fire(bool isFire)
    {
        if(isFire)
            fireParticles.Play();
        else
            fireParticles.Stop();
    }

    void FireBallAttack()
    {
        animation.SetBool("FireAt", true);
    }

    void BiteAttack()
    {
        animation.SetBool("BiteAt", true);

    }

    void TailAttack()
    {
        animation.SetBool("TailAt", true);

    }
}
