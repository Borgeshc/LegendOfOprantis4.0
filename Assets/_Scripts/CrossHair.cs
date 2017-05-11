using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour {

    public Texture2D crossHairTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot;

    Vector3 posCenterx, posCentery;
    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;

        hotSpot = new Vector2(-80, -80);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
           
            Cursor.visible = true;

            Cursor.SetCursor(crossHairTexture, hotSpot, cursorMode);

            Cursor.lockState = CursorLockMode.Locked;


        }
        else
        {
            Cursor.visible = false;

        }
    }


}
