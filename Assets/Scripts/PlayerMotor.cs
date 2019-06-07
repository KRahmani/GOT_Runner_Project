using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 8.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float jump = 80;

    private Animator anim;

    private float animationDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        //if i'm on the floor
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed ;

        //up and down
        moveVector.y = verticalVelocity;
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetTrigger("Down");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetTrigger("Jump");
            //moveVector.y += jump;
        }


        //forward and backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }


}
