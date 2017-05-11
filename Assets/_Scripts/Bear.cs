using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

    private Animator anim;

    public Transform bear;

    public Transform player;

    public float distancia, distCorrida;

    private bool isRunning2;

    private bool isAttacking;

    public float time;

    private Vector3 initPos;

    void Start () {
        anim = GetComponent<Animator>();

        isRunning2 = false;
  
        time = 0;

        initPos = bear.position;
    }
	
	// Update is called once per frame
	void Update () {

        distancia = Vector3.Distance(player.position, bear.position);

        //distCorrida = Vector3.Distance(initPos, bear.position);

        time += Time.deltaTime;

        if (time > 5f)
        {
            
            time = 0;

            int i = (Random.Range(1, 3));

  
            if (i == 1)
            {
                anim.SetBool("IdleChange", true);
            }
            if (i == 2)
            {
                anim.SetBool("IdleChange", false);
            }
          
        }

        if (distancia < 17)
        {

            if (distancia > 14)
            {
                isRunning2 = true;
            
                //bear.Translate(Vector3.forward * 0 * Time.deltaTime);
                //anim.SetBool("IsRunning", false);


            }
        }


        if (isRunning2 == true)
        {
            anim.SetBool("IdleChange", false);
            anim.SetBool("IsRunning", true);

            Vector3 direction = player.transform.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
               Quaternion.LookRotation(direction), 0.1f);
            this.transform.Translate(Vector3.forward * 3 * Time.deltaTime);

            //bear.LookAt(player.position);
            //bear.Translate(Vector3.forward * 3 * Time.deltaTime);

            if (distancia < 3.5f)
            {
                isRunning2 = false;

                bear.Translate(Vector3.forward * 0 * Time.deltaTime);
               
   
                anim.SetBool("IsAttacking", true);
                anim.SetBool("IsRunning", false);
                

            }
            else 
            {
                
                //anim.SetBool("IsRunning", true);

                anim.SetBool("IsAttacking", false);

            }

        }
        else
        {
            anim.SetBool("IsRunning", false);

            bear.Translate(Vector3.forward * 0 * Time.deltaTime);
        }



        //Debug.Log("isRunning" + isRunning2);
        //Debug.Log("isAttavking" + isAttacking);


        if (distancia > 25)
        {
            isRunning2 = false;
            bear.Translate(Vector3.forward * 0 * Time.deltaTime);

            //bear.Translate(Vector3.forward * 0 * Time.deltaTime);
            //anim.SetBool("IsRunning", false);


        }

    }
}
