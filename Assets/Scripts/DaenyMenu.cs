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
        


        Scene game=SceneManager.GetSceneByName ("Game");

        Scene active =SceneManager.GetActiveScene();

        //GameObject[] objects = game.GetRootGameObjects();

        Scene[] scenes = SceneManager.GetAllScenes();

        foreach(Scene s in scenes)
        {
            s.GetRootGameObjects();
        }

        /*
        foreach (GameObject g in objects)
        {
            if (g.name == "Player")
            {
                g.SetActive(true);
            }
            if (g.name == "Player1")
            {
                g.SetActive(false);
            }
        }
        */

        //daenyPlayer = GameObject.Find("Player");
        //jonPlayer = GameObject.Find("Player1");
        daenyPlayer.SetActive(true);
        jonPlayer.SetActive(false);

        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

}
