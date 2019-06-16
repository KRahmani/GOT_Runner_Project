using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaenyMenu : MonoBehaviour
{
    private GameObject daenyPlayer,jonPlayer;
    public static string selectedCharacterName;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toJon()
    {
        SceneManager.LoadScene("Jon-player");
    }

    public void selectDaenyPlayer()
    {
        GameObject.Find("MainMenu").GetComponent<MainMenu>().playerChoise = 0;

        SceneManager.LoadScene("Menu");
    }

}
