using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rabbit : MonoBehaviour {

    public Animation anim;

    public Transform coelho;

    public Transform player;

    public float distancia;

    private bool isRunning;

	// Use this for initialization
	void Start () {

        isRunning = false;
        anim.Play("idle1");

	}
	
	// Update is called once per frame
	void Update () {

        distancia = Vector3.Distance(player.position, coelho.position);

        if (distancia < 10)
        {
            isRunning = true;
            
        }

        if (isRunning == true)
         {
             anim.Play("run");

            coelho.LookAt(player.position);
            coelho.Rotate(0, 180, 0);
            coelho.Translate(Vector3.forward * 4 * Time.deltaTime);

        }

        if (distancia > 40)

        {
            isRunning = false;
            anim.Play("idle1");
            coelho.Translate(Vector3.forward * 0 * Time.deltaTime);

        }
       
    }
}
