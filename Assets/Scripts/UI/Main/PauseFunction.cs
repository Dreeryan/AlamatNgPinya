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
        Time.timeScale = 0.0f; // Freezes the game
        pauseButton.SetActive(false); // Hides Pause Button
        PauseMenu.SetActive(true); // Opens Pause Menu UI
    }

    public void Resume() // Continues the game via timescale and closes pause menu
    {
        Time.timeScale = 1.0f; // Unfreezes the game
        pauseButton.SetActive(true); // Shows Pause Button
        PauseMenu.SetActive(false); // Closes Pause Menu UI
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f; 
        SceneManager.LoadScene("MainMenu"); // Switches to the Main Menu scene
    }
}
