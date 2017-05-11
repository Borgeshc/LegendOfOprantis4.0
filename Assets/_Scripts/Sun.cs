using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float time;

    public Light sunLight;

    public Light MoonLight;

    public GameObject[] lampLights;

    // Use this for initialization
    void Start()
    {
        time = 0;

        lampLights = GameObject.FindGameObjectsWithTag("light");


        foreach (GameObject lights in lampLights)
        {
            lights.gameObject.SetActive(false);


        }
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        transform.RotateAround(Vector3.zero, Vector3.right, 2 * Time.deltaTime);
        transform.LookAt(Vector3.zero);
        //Debug.Log(transform.rotation.x);
        if (time > 45 && time < 130) // 40 segundos
        {
            foreach (GameObject lights in lampLights)
            {
                lights.gameObject.SetActive(true);


            }

            if (sunLight.intensity >= 0)
            {
                sunLight.intensity -= 0.04f;
            }

            if (MoonLight.intensity < 0.44f)
            {
                MoonLight.intensity += 0.001f;
            }

            if (RenderSettings.ambientIntensity > 0)
            {
                RenderSettings.ambientIntensity -= 0.004f;
            }


            if (RenderSettings.reflectionIntensity > 0)
            {
                RenderSettings.reflectionIntensity -= 0.004f;

            }
            //if (transform.rotation.x > 0.0276116) ;
            //{
            //    RenderSettings.ambientIntensity = 1f;
            //}
        }
        else
        {

            foreach (GameObject lights in lampLights)
            {
                lights.gameObject.SetActive(false);


            }

            if (sunLight.intensity < 0.5f)
            {
                sunLight.intensity += 0.0013f;      //sunLight.intensity = 0.5f;
            }
            if (MoonLight.intensity > 0.0f)
            {
                MoonLight.intensity -= 0.025f;
            }
            if (RenderSettings.ambientIntensity < 1)
            {
                RenderSettings.ambientIntensity += 0.003f;
            }

            if (RenderSettings.reflectionIntensity < 0.746f)
            {
                RenderSettings.reflectionIntensity += 0.003f;

            }

        }

        if (time >= 180)
        {
            time = 0;
        }

    }
}
