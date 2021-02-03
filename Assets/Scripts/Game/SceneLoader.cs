using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : BaseManager<SceneLoader>
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        if (sceneName == "MainMenu")
        {
            Time.timeScale = 1.0f;
        }
    }
}
