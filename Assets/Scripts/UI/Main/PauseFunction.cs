using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseFunction : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseButton != null)
            pauseButton.SetActive(true);

        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        // Freezes the game
        Time.timeScale = 0.0f;

        // Hides Pause Button
        if (pauseButton != null)
            pauseButton.SetActive(false);

        // Opens Pause Menu UI
        if (pauseMenu != null)
            pauseMenu.SetActive(true); 
    }

    // Continues the game via timescale and closes pause menu
    public void Resume() 
    {
        // Unfreezes the game
        Time.timeScale = 1.0f;

        // Shows Pause Button
        if (pauseButton != null)
            pauseButton.SetActive(true);

        // Closes Pause Menu UI
        if (pauseMenu != null)
            pauseMenu.SetActive(false); 
    }

    public void MainMenu()
    {
        // Switches to the Main Menu scene
        SceneManager.LoadScene("MainMenu"); 
    }

    //A: Should probably create a private set method to handle the timescale change AND object active set so you dont have to do it twice

    private void ToggleTimeScaleAndPauseUI(bool isPaused)
    {
        Time.timeScale = (isPaused) ? 0.0f : 1.0f;

        if (pauseButton != null)
            pauseButton.SetActive(!isPaused);

        if (pauseMenu != null)
            pauseMenu.SetActive(isPaused);
    }
}
