using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent : MonoBehaviour {

    public Transform player;

    private Animator animation;

    public bool IsChasing, isStartPos;

    private float distance, startDistance;

    private Vector3 startPos;

    void Start () {

        animation = GetComponent<Animator>();

        IsChasing = false;

        isStartPos = true;

        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(player.position, this.transform.position);

        startDistance = Vector3.Distance(startPos, this.transform.position);

        if (distance < 20)
        {

            IsChasing = true;

            animation.SetBool("Roar", true);

            Invoke("Walking", 1.7f);


            if (distance < 4)
            {
                IsChasing = false;

                animation.SetBool("Attack", true);
            }
            else
            {
                animation.SetBool("Attack", false);

            }


        }
        else
        {
            IsChasing = false;

            Invoke("CommingBack", 1.7f);

        }
    }

    void CommingBack()
    {
        if (!isStartPos)
        {
            Vector3 direction = startPos - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
            this.transform.Translate(Vector3.forward * 2 * Time.deltaTime);

            animation.SetBool("isWalking", true);


        }
        

        if (startDistance < 2)
        {
            animation.SetBool("isWalking", false);
            animation.SetBool("Roar", false);

            isStartPos = true;
        }
    }

    void Walking()
    {
        if (IsChasing == true)
        {
            isStartPos = false;

            animation.SetBool("isWalking", true);

            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            this.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        else
        {
            animation.SetBool("isWalking", false);

        }
    }
}
