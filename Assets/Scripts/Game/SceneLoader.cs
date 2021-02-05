using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : BaseManager<SceneLoader>
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;       
    }

    public void OpenPopup(string popupName)
    {
        SceneManager.LoadScene(popupName, LoadSceneMode.Additive);
    }

    public void ClosePopup(string popupName)
    {
        SceneManager.UnloadSceneAsync(popupName);
    }
}
