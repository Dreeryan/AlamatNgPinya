using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TagManager : MonoBehaviour
{
    private UnityEvent  onMinigameCompleted = new UnityEvent();
    public UnityEvent   OnMinigameCompleted
    {
        get { return onMinigameCompleted; }
    }

    [SerializeField] private GameObject     winScreen;

    [SerializeField] private TagCharacter[] kids;
    [SerializeField] private TagCharacter   startingTagged;

    private TagCharacter currentTagged;

    void Start()
    {
        if (winScreen != null) winScreen.SetActive(false);

        // Adds listener for when a kid gets tagged
        foreach (TagCharacter kid in kids)
        {
            kid.tagged.AddListener(OnCurrentTaggedChange);
            kid.DebugUpdateColor();
        }

        currentTagged = startingTagged;
        currentTagged.IsTagged = true;
        currentTagged.DebugUpdateColor();
    }

    // Changes the current tagged kid
    void OnCurrentTaggedChange(TagCharacter newTagged) 
    {
        currentTagged.IsTagged = false;

        currentTagged = newTagged;
        currentTagged.IsTagged = true;

        // If the current tagged is one of the other kids, complete the minigame
        if (currentTagged.CompareTag("Enemy")) OnComplete();
    }

    void OnComplete()
    {
        DisplayWinScreen();
        onMinigameCompleted.Invoke();
        //Time.timeScale = 0.0f;
    }

    void DisplayWinScreen() 
    {
        winScreen.SetActive(true);
    }
}
