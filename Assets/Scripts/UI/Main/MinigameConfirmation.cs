using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameConfirmation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.IsPaused = true;
    }

    public void StartMinigame()
    {
        GameManager.Instance.IsPaused = false;
        TimerManager.Instance.StartTimer();
        SceneLoader.Instance.ClosePopup(gameObject.scene.name);
    }

    public void ReturnToMenu()
    {
        SceneLoader.Instance.ChangeScene("MainMenu");
    }
}
