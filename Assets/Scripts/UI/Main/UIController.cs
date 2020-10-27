using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] private Interactable interactable;

    // Calls the loadminigame function to load minigame scene
    public void Play()
    {
		//A: Nullcheck
        if (interactable != null) interactable.LoadMinigame();
    }

}
