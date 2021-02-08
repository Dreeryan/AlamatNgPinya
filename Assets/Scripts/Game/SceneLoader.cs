using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : BaseManager<SceneLoader>
{
    public void ChangeScene(string sceneName, bool isPopup = false)
    {
        LoadSceneMode mode;
        if (isPopup) mode = LoadSceneMode.Additive;
        else mode = LoadSceneMode.Single;

        SceneManager.LoadScene(sceneName, mode);
        Time.timeScale = 1.0f;       
    }

    public void ClosePopup(string popupName)
    {
        SceneManager.UnloadSceneAsync(popupName);
    }
}
