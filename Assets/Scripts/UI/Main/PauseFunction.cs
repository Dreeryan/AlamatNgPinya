using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseFunction : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject askMomButton;

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

        // Hides Ask Mom Button
        if (askMomButton != null)
            askMomButton.SetActive(false);

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

        // Shows Ask Mom Button
        if (askMomButton != null)
            askMomButton.SetActive(true);

        // Closes Pause Menu UI
        if (pauseMenu != null)
            pauseMenu.SetActive(false); 
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
