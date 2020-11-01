using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseFunction : MonoBehaviour
{
    public GameObject pauseButton;
	//A: should camelCase
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
		//A: Nullcheck
        pauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        // Freezes the game
        Time.timeScale = 0.0f;
		//A: Nullcheck
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
		//A: Nullcheck
        // Shows Pause Button
        pauseButton.SetActive(true);
        // Closes Pause Menu UI
        PauseMenu.SetActive(false); 
    }

    public void MainMenu()
    {
		//A: This is a bit dangerous and possibly confusing if another script will do Back to main logic
        Time.timeScale = 1.0f;
        // Switches to the Main Menu scene
        SceneManager.LoadScene("MainMenu"); 
    }
	
	//A: Should probably create a private set method to handle the timescale change AND object active set so you dont have to do it twice
	
	/*private void ToggleTimeScaleAndPauseUI(bool isPaused)
	{
		Time.timeScale = (isPaused) ? 0.0f : 1.0f;
		
		if(pauseButton != null)
			pauseButton.SetActive(!isPaused);
		
		if(PauseMenu != null)
			PauseMenu.SetActive(isPaused);
	}*/
}
