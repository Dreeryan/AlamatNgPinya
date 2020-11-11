using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    public  TextMeshProUGUI counterText;
    public  int             trashCollected;
    private int             previousTrashCollected;

    [SerializeField] private int        trashGoal;
    [SerializeField] private Draggable  broom;
    [SerializeField] private GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        previousTrashCollected = trashCollected;

        // Sets the goal to how many sweepable objects are present
        trashGoal = GameObject.FindGameObjectsWithTag("SweepableObject").Length;

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if trash is collected
        if (trashCollected > previousTrashCollected)
        {
            previousTrashCollected = trashCollected;

            // If goal is reached, broom will be unusuable
            if (trashCollected >= trashGoal)
            {
                broom.isPlaced = true;
                winScreen.SetActive(true);
            }
        }

        counterText.text = "Trash collected: " + trashCollected + " / " + trashGoal;
    }
}
