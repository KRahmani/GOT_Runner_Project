using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 distanceFromPlayer;
    private Vector3 moveVector;

    private float flyingUpDuration = 1.0f;

    // Use this for initialization
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceFromPlayer = transform.position - lookAt.position;

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + distanceFromPlayer;


        //one second after starting the game
        if (Time.time > flyingUpDuration)
        {
            transform.position = moveVector;

        }
        //at the start of the game
        else
        {
            moveVector.y += 0.02f;
            transform.position = moveVector;
        }
    }
}
