using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject playSound;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        playSound.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        playSound.SetActive(false);
        scoreText.text = ((int)score).ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
