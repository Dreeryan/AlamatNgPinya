using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
   public void PlayAudio(string audioId)
    {
        AudioManager.PlayAudio(audioId);
    }

    public void LoadScene(string sceneName)
    {
        //if (SceneLoader.Instance == null) return;
        SceneLoader.ChangeScene(sceneName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
