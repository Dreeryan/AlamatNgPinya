using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : MonoBehaviour
{
    public int trashCollected;
    private GameObject[] getCount;

    [SerializeField] private int        trashGoal;
    [SerializeField] private Draggable  broom;

    // Start is called before the first frame update
    void Start()
    {
        // Detects how many SweepableObjects are present in the scene
        getCount = GameObject.FindGameObjectsWithTag("SweepableObject");

        // Sets the goal to how many sweepable objects are present
        trashGoal = getCount.Length;
        trashCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If goal is reached, broom will be unusuable
        if (trashCollected == trashGoal)
        {
            broom.isPlaced = true;
        }
    }
}
