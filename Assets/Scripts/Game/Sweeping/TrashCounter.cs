using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : MonoBehaviour
{
    public int trashCollected;
    private int previousTrashCollected;

    [SerializeField] private int        trashGoal;
    [SerializeField] private Draggable  broom;

    // Start is called before the first frame update
    void Start()
    {
        previousTrashCollected = trashCollected;

        // Sets the goal to how many sweepable objects are present
        trashGoal = GameObject.FindGameObjectsWithTag("SweepableObject").Length;
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
                Debug.Log("broom");
                broom.isPlaced = true;
            }
        }
    }
}
