using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    [SerializeField] private GameObject     winScreen;

    [SerializeField] private TagCharacter[] kids;
    [SerializeField] private TagCharacter   startingTagged;
    private TagCharacter currentTagged;

    void Start()
    {
        // Adds listener for when a kid gets tagged
        foreach (TagCharacter kid in kids)
        {
            kid.onTagged.AddListener(OnCurrentTaggedChange);
        }

        currentTagged = startingTagged;
        currentTagged.IsTagged = true;
    }

    void Update()
    {
        
    }

    // Changes the current tagged kid
    void OnCurrentTaggedChange(TagCharacter newTagged) 
    {
        currentTagged.IsTagged = false;
        currentTagged = newTagged;
        currentTagged.IsTagged = true;

        // If the current tagged is one of the other kids, complete the minigame
        if (currentTagged.CompareTag("Enemy")) DisplayWinScreen();
    }

    void DisplayWinScreen() 
    {
        winScreen.SetActive(true);
    }
}
