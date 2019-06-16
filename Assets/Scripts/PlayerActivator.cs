using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    private int playerChoise;
    public GameObject firstPlayer, secondPlayer;
    void Start()
    {
        playerChoise = GameObject.Find("MainMenu").GetComponent<MainMenu>().playerChoise;

        if (playerChoise == 1)
        {
            firstPlayer.SetActive(false);
            GameObject.Find("Main Camera").GetComponent<CameraMotor>().playerToFollow = secondPlayer;
            secondPlayer.SetActive(true);
        }
        if (playerChoise == 0)
        {
            firstPlayer.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<CameraMotor>().playerToFollow = firstPlayer;
            secondPlayer.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
