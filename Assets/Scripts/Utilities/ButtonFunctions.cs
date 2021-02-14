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
        TimerManager.Instance.StopTimer();

        SceneLoader.Instance.LoadScene(sceneName);
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
        TimerManager.Instance.StopTimer();

        if (MotivationManager.Instance.HasEnoughMotivation())
            SceneLoader.Instance.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        GameManager.Instance.IsPaused = true;
    }

    public void PlayGame()
    {
        GameManager.Instance.IsPaused = false;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
