using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseFunction : MonoBehaviour
{
    public void Pause()
    {
        // Freezes the game
        Time.timeScale = 0.0f;

        SceneLoader.Instance.LoadScene("PauseMenu", true);
    }

    // Continues the game via timescale and closes pause menu
    public void Resume() 
    {
        // Unfreezes the game
        Time.timeScale = 1.0f;

        SceneLoader.Instance.ClosePopup("PauseMenu");
    }
}
