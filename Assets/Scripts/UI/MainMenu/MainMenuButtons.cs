using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    // Loads the minigame selection
    public void LoadSelectionScene()
    {
        SceneManager.LoadScene("MinigameSelection");
    }

    // Quits the game
    public void ExitBtn()
    {
        Application.Quit();
    }
}
