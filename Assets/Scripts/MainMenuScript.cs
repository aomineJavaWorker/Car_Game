using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void ChangeSceneSample()
    {
        SceneManager.LoadScene("CityScene");
    }

    public void ChangeSceneMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}

