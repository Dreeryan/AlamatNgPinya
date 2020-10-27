using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScene : MonoBehaviour
{
    // Loads the minigame selection
    public void LoadSelectionScene()
    {
        SceneManager.LoadScene("MinigameSelection");
    }

    // Loads a minigame based on the scenename
    public void LoadMinigame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}