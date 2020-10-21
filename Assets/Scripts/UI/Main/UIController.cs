using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Calls the loadminigame function to load minigame scene
    public void Play()
    {
        interactable.LoadMinigame();
    }

}
