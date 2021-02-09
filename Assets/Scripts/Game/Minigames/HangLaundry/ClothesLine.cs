using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesLine : MonoBehaviour
{
    [SerializeField] private Counter counter;
    // Make "First in First out" kind of placement
    [SerializeField] private List<Transform> clothingSpots;
    private int indexNum;

    private void Start()
    {
        indexNum = 0;

        if (counter == null) counter = FindObjectOfType<Counter>();
    }

    public void HangClothing(ClothesToHang clothing)
    {
        Transform hangSpot = GetNextAvailablePosition();

        clothing.transform.parent = hangSpot;
        clothing.transform.position = hangSpot.position;

        UpdateIndex();

        if (counter != null) counter.IncreaseProgress();
    }

    // Calls for the next position available in the index
    private Transform GetNextAvailablePosition()
    {
        if (clothingSpots.Count == 0)
        {
            Debug.LogErrorFormat("No spots available");
            return null;
        }

        return clothingSpots[indexNum].transform;
    }

    // Moves the index to the next empty one
    private void UpdateIndex()
    {
        if (indexNum != clothingSpots.Count)
            indexNum++;
    }
}
