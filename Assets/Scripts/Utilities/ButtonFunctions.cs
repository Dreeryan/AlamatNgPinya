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
        SceneLoader.Instance.ChangeScene(sceneName);
    }

    public void StartTimer()
    {
        TimerManager.Instance.StartTimer();
    }
    
    public void StopTimer()
    {
        TimerManager.Instance.StopTimer();
    }

    public void LoadChoreMinigame(string sceneName)
    {
        if (MotivationManager.Instance == null) return;

        if (MotivationManager.Instance.HasEnoughMotivation())
            SceneLoader.Instance.ChangeScene(sceneName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
