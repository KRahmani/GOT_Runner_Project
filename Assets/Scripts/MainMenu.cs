using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int playerChoise;
    private static bool created = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToJon()
    {
        SceneManager.LoadScene("Jon-player");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
