using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("FlyingTesla");
    }
    public void LaunchesButton()
    {
        SceneManager.LoadScene("Launches");
    }
    public void AboutButton()
    {
        SceneManager.LoadScene("About");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        bool isLoaded = false;

        if (SceneManager.GetActiveScene().name == "FlyingTesla")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (SceneManager.GetActiveScene().name == "First")
        {
            if (Input.anyKeyDown)
            {
                if (!isLoaded)
                {
                    SceneManager.LoadScene("MainMenu");
                    isLoaded = true;
                }
            }
        }
    }

}
