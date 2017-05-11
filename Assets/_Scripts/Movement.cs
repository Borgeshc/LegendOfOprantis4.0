using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Animator animation;
    public Transform playerTransform;

    Arrow arrow;
    public float speed = 1f, rotationSpeed, runSpeed, jumpTime = 0f;
    private bool isWalkingFront, isWalkingBack, isTurningRight, isTurningLeft, isRunning, isJumping, shoot;

    private float currentY = 0.0f;

    private float currentX = 0.0f;

    public Transform target;

    private const float X_ANGLE_MIN = 15.0f;
    private const float X_ANGLE_MAX = 50.0f;

    private const float Y_ANGLE_MIN = -14.0f;
    private const float Y_ANGLE_MAX = 7.0f;

    public Transform cam;


    void Start ()
    {
        animation = GetComponent<Animator>();

        transform.Rotate(Vector3.up * -90);

        isWalkingFront = false;
        isWalkingBack = false;
        isTurningLeft = false;
        isTurningRight = false;
        isRunning = false;
        isJumping = false;

        arrow = new Arrow();

    }
	
	void Move()
    {


        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * speed * Time.deltaTime);
            isWalkingFront = true;
        }
        else
        {
            isWalkingFront = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * speed * Time.deltaTime);
            isWalkingBack = true;
         
        }
        else
        {
            isWalkingBack = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
                //isTurningLeft = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            //isTurningRight = true;
        }

        if (Input.GetMouseButton(1))
        {
            playerTransform.transform.forward = cam.transform.forward;

            //if (Input.GetAxis("Mouse X") < 0)
            //{
            //    playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            //    isTurningLeft = true;
            //}
        }
        else
        {
            isTurningLeft = false;
        }
        //if (Input.GetMouseButton(1))
        //{

        //    //if (Input.GetAxis("Mouse X") > 0)
        //    //{
        //    //    playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        //    //    isTurningRight = true;
        //    //}
        //}
        //else
        //{
        //    isTurningRight = false;
        //}



        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalkingFront = false;
            isWalkingBack = false;
            isRunning = true;
            Run();
        }
        else
        {
            isRunning = false;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            isJumping = true;
            StandingJump();
        }
        
        
    }
    
    
    void Run()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
       
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * runSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    void StandingJump()
    {
        if (isJumping == true)
        {
            animation.SetBool("isJumping", true);
            Invoke("StopJumping", 0.1f);
        }
    }
    

    void StopJumping()
    {
        animation.SetBool("isJumping", false);
    }


    void AnimationControl()
    {
        if(isWalkingFront == true)
            {
           

            animation.SetBool("isWalkingFront", true);

                if (Input.GetMouseButton(1))
                {
               
                    animation.SetBool("AimWalk", true);

                }
                else
                {
                    animation.SetBool("AimWalk", false);
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    animation.SetBool("Jump_run", true);
                }

                else
                {
                    animation.SetBool("Jump_run", false);

                }
            }

            else
            {
                animation.SetBool("isWalkingFront", false);
            }


        if (isWalkingBack == true)
            {
                animation.SetBool("isWalkingBack", true);
            }

            else
            {
                animation.SetBool("isWalkingBack", false);
            }


        if (isRunning == true)
            {
                animation.SetBool("isRunning", true);

                if (Input.GetKey(KeyCode.Space))
                {
                    animation.SetBool("Jump_run", true);


                }
                else
                {
                    animation.SetBool("Jump_run", false);
                }


                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    animation.SetBool("isRolling", true);

                }
                else
                {

                    animation.SetBool("isRolling", false);

                }

            }

            else
            {
                animation.SetBool("isRunning", false);
            }



        if (isTurningRight == true)
            {
                animation.SetBool("TurningRight", true);
            }

            else
            {
                animation.SetBool("TurningRight", false);

            }


        if (isTurningLeft == true)
            {
                animation.SetBool("TurningLeft", true);
            }

            else
            {
                animation.SetBool("TurningLeft", false);
            }



        if (Input.GetMouseButton(1))
            {
                animation.SetBool("IsAiming", true);
            

        }
            else
            {
                animation.SetBool("IsAiming", false);
            }


        if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && arrow.standingtime == false)
            {
                animation.SetBool("isShooting", true);
            }
            else
            {
                animation.SetBool("isShooting", false);
            }
    }

    void Update()
    {
        Debug.Log(arrow.standingtime);

        currentY += Input.GetAxis("Mouse Y");
        currentX += Input.GetAxis("Mouse X");


        Move();
        AnimationControl();

        //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        if (animation.GetBool("IsAiming") == true)
        {
            //Debug.Log(currentY);

            //cam.LookAt(currentY);
            if (currentY < Screen.height)
            {
               
                animation.SetFloat("AimingAngle", -currentY *6);
                
            }
        }
        else
        {
            animation.SetFloat("AimingAngle", -6);
            animation.SetFloat("IsAiming", -6);
        }

       
    }


}
