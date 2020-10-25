using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScene : MonoBehaviour
{
	//A: This entire script is gonna be a pain in the future.
	// I recommend instead to have the function take in a string sceneName then load that sceneName
	
    // Loads the clean up minigame
    public void PlayCleanUpMinigame()
    {
        SceneManager.LoadScene("CleanUp");
    }

    // Loads the cook porridge minigame
    public void PlayCookPorridgeMinigame()
    {
        SceneManager.LoadScene("CookPorridge");
    }

    // Loads the dish washing minigame
    public void PlayDishWashingMinigame()
    {
        SceneManager.LoadScene("DishWashing");
    }

    // Loads the feed animals minigame
    public void PlayFeedAnimalsMinigame()
    {
        SceneManager.LoadScene("FeedAnimals");
    }


    // Loads the floor sweep minigame
    public void PlayFloorSweepMinigame()
    {
        SceneManager.LoadScene("FloorSweeping");
    }

    // Loads the fold laundry minigame
    public void PlayFoldLaundryMinigame()
    {
        SceneManager.LoadScene("FoldLaundry");
    }

    // Loads the grab eggs minigame
    public void PlayGrabEggsMinigame()
    {
        SceneManager.LoadScene("GrabEggs");
    }

    // Loads the hang laundry minigame
    public void PlayHangLaundryMinigame()
    {
        SceneManager.LoadScene("HangLaundry");
    }

    // Loads the water plants minigame
    public void PlayWaterPlantsMinigame()
    {
        SceneManager.LoadScene("PlantWatering");
    }

    // Loads the plates at dishrack minigame
    public void PlayPlatesAtDishrackMinigame()
    {
        SceneManager.LoadScene("PlatesAtDishrack");
    }

    // Loads the minigame selection
    public void LoadSelectionScene()
    {
        SceneManager.LoadScene("MinigameSelection");
    }
}