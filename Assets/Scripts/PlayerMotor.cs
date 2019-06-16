using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 7.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;


    private float jump = 80;

    private Animator anim;

    private float animationDuration = 3.0f;

    private bool isDead = false;

    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startTime = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        if(Time.time - startTime < animationDuration)
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

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("Down");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }


        //forward and backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
        if (transform.position.y < -1.5f)
        {
            Death();
        }
    }
    
    public void SetSpeed(float modifier)
    {
        speed =7.0f+modifier;
    }

    //called every time the capsule of the player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag=="Obstacle")
        {
            Death();
        }

    }



    private void Death()
    {
        //Debug.Log("Dead");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}
