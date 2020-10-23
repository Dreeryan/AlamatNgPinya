using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseFunction : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        // Freezes the game
        Time.timeScale = 0.0f;
        // Hides Pause Button
        pauseButton.SetActive(false);
        // Opens Pause Menu UI
        PauseMenu.SetActive(true); 
    }

    // Continues the game via timescale and closes pause menu
    public void Resume() 
    {
        // Unfreezes the game
        Time.timeScale = 1.0f;
        // Shows Pause Button
        pauseButton.SetActive(true);
        // Closes Pause Menu UI
        PauseMenu.SetActive(false); 
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        // Switches to the Main Menu scene
        SceneManager.LoadScene("MainMenu"); 
    }
}
