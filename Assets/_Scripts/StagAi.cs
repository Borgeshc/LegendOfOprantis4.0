using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagAi : MonoBehaviour {


    public Animation anim;

    public Transform stag;

    public Transform player;

    public float distancia;

    private bool isRunning;

    public float smooth = 1f;

    private Quaternion targetRotation;

    void Start () {

        isRunning = false;
        anim.Play("idle1");
    }
	
	// Update is called once per frame
	void Update () {

        distancia = Vector3.Distance(player.position, stag.position);

   

        if (distancia < 10)
        {
            isRunning = true;

        }

        if (isRunning == true)
        {
            anim.Play("run");

            stag.LookAt(player.position);
            stag.Rotate(0, 180, 0);
            stag.Translate(Vector3.forward * 4 * Time.deltaTime);

        }

        if (distancia > 40)

        {
            isRunning = false;
            anim.Play("idle1");
            stag.Translate(Vector3.forward * 0 * Time.deltaTime);

        }
    }
}
