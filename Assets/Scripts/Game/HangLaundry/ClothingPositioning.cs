using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingPositioning : MonoBehaviour
{
    // Make "First in First out" kind of placement
    [SerializeField] private List<GameObject> clothingSpots;
    [SerializeField] private bool             isMouseUp;
    private int indexNum;

    private void Start()
    {
        indexNum = 0;
    }

    // Calls for the next position available in the index
    public Vector3 GetNextAvailablePosition()
    {
        if (gameObject.tag == "Item")
        {
            GameObject shirt = gameObject;

            // Sets shirt as a child of the position then changes their position to 0
            shirt.transform.parent = clothingSpots[indexNum].transform;
            shirt.transform.localPosition = Vector3.zero;
        }

        return clothingSpots[indexNum].transform.position;
    }

    // Moves the index to the next empty one
    public void UpdateIndex()
    {
        if (indexNum != clothingSpots.Count)
            indexNum++;
    }
}
