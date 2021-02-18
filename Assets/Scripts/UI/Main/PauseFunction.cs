using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseFunction : MonoBehaviour
{
    public void Pause()
    {
        // Freezes the game
        GameManager.Instance.IsPaused = true;

        SceneLoader.Instance.LoadScene("PauseMenu", true);
    }

    // Continues the game via timescale and closes pause menu
    public void Resume() 
    {
        // Unfreezes the game
        GameManager.Instance.IsPaused = false;

        SceneLoader.Instance.ClosePopup("PauseMenu");
    }
}
