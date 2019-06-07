using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 distanceFromPlayer;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 6, 5);

    // Use this for initialization
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceFromPlayer = transform.position - lookAt.position;

    }

    // Update is called once per frame
    void Update()
    {
        //the camera will follow the player
        moveVector = lookAt.position + distanceFromPlayer;

        //X
        moveVector.x = 0; //let the camera in the middle

        //Y
        moveVector.y = Mathf.Clamp(moveVector.y, 2, 5);

        //one second after starting the game
        if (transition > 1.0f)
        {
            transform.position = moveVector;

        }
        // animation at the start of the game = 2 seconds
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
