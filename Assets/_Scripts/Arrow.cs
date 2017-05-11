using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private GameObject arrowPrefab;
    public Transform player;

    public bool standingtime;

    float time;

    private float currentX = 0.0f;

    private float currentY = 0.0f;

    private const float Y_ANGLE_MIN = 5.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    Vector3 p = new Vector3();
    Camera c;
    


    Vector3 dir;
    // Use this for initialization
    void Start ()
    {
        standingtime = true;
        arrowPrefab = Resources.Load("ErikaArrow 1 1 1") as GameObject;

        c = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
    


        p = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 80, Input.mousePosition.y - 80, -c.nearClipPlane));

        dir = (p - player.transform.position);

        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && time > 1)
        {
            standingtime = false;
            GameObject newArrow = Instantiate(arrowPrefab) as GameObject;
            newArrow.transform.position = player.transform.position + Vector3.up * 1.5f;
            newArrow.transform.rotation = transform.rotation;

            Rigidbody rb = newArrow.GetComponent<Rigidbody>();
            rb.AddForce(dir * 5, ForceMode.Impulse);

            
            Destroy(newArrow, 5);

            time = 0;
        }

        standingtime = true;
	}
}
