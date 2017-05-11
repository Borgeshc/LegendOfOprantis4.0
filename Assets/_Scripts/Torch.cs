using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {


    public GameObject bow;

    public GameObject torch;

    private Animator animation;

    public ParticleSystem fireParticle;

    public bool holdTorch;

    public GameObject[] torchLight;
    // Use this for initialization
    void Start () {

        holdTorch = false;

        torch.gameObject.GetComponent<Renderer>().enabled = false;

        fireParticle.gameObject.GetComponent<Renderer>().enabled = false;

        animation = GetComponent<Animator>();

        torchLight = GameObject.FindGameObjectsWithTag("TorchLight");

        foreach (GameObject lights in torchLight)
        {
            lights.gameObject.SetActive(false);


        }
    }

    // Update is called once per frame
    void Update () {



        if (Input.GetKeyDown(KeyCode.T))
        {
            holdTorch = true;


            
        }

        if(holdTorch)
        {
            animation.SetBool("Torch", true);

            fireParticle.gameObject.GetComponent<Renderer>().enabled = true;

            bow.gameObject.GetComponent<Renderer>().enabled = false;
            torch.gameObject.GetComponent<Renderer>().enabled = true;

            foreach (GameObject lights in torchLight)
            {
                lights.gameObject.SetActive(true);


            }

            if (Input.GetKey(KeyCode.W))
            {
                animation.SetBool("TorchWalk", true);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animation.SetBool("TorchRun", true);

                }

                else
                {
                    animation.SetBool("TorchRun", false);

                }
                
            }
            else
            {
                animation.SetBool("TorchWalk", false);

            }
        }
        else
        {
            animation.SetBool("Torch", false);

            fireParticle.gameObject.GetComponent<Renderer>().enabled = false;

            bow.gameObject.GetComponent<Renderer>().enabled = true;
            torch.gameObject.GetComponent<Renderer>().enabled = false;

            foreach (GameObject lights in torchLight)
            {
                lights.gameObject.SetActive(false);


            }

        }

        if (Input.GetKeyDown(KeyCode.Y))

        {
            holdTorch = false;


        }
    }
}
