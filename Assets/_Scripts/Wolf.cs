using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    public Animation anim;

    public Transform wolf;

    public Transform player;

    public float distancia;

    private bool isRunning;

    private bool isAttacking;



    // Use this for initialization
    void Start () {

        anim.Play("idleLookAround");

        isAttacking = false;

    }

    // Update is called once per frame
    void Update () {

        distancia = Vector3.Distance(player.position, wolf.position);

        if (distancia < 10)
        {
            isRunning = true;

        }

        if (distancia < 2)
        {
            isAttacking = true;
            isRunning = false;

        }
        if(isAttacking == true)
        {
            anim.Play("standBite");

            if (distancia > 2)
            {
                isAttacking = false;
                isRunning = true;

            }
        }

       

        if (isRunning == true)
        {
            anim.Play("run");

            Vector3 direction = player.transform.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);


            wolf.Translate(Vector3.forward * 3.4f * Time.deltaTime);

        }


    }
}
