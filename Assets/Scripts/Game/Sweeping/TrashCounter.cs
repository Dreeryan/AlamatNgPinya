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
		
		//A: Can shorten this to just 
		//trashGoal = GameObject
		//	.FindGameObjectsWithTag("SweepableObject").Length;
		//A: So you wont have to make an array thats only used once. Waste of memory especially its a script scoped var rather than method scoped
		
        // Sets the goal to how many sweepable objects are present
        trashGoal = getCount.Length;
		
        trashCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
		//A: Try to move this to only when the trash gets collected
        // If goal is reached, broom will be unusuable
        if (trashCollected == trashGoal)
        {
            broom.isPlaced = true;
        }
    }
}
