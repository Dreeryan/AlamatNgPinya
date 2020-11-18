using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        if (sceneName == "MainMenu")
        {
            Time.timeScale = 1.0f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
