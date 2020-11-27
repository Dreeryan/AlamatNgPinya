using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingPositioning : MonoBehaviour
{
    // Make "First in First out" kind of placement
    [SerializeField] private List<GameObject> clothingSpots;
    [SerializeField] private List<GameObject> clothing = new List<GameObject>();
    private int indexNum;

    private void Start()
    {
        indexNum = 0;
    }

    private void Update()
    {
        Debug.Log(indexNum);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int index = clothingSpots.IndexOf(clothingSpots[indexNum]);

        if (index != null)
        {
            if (indexNum != clothingSpots.Count)
                indexNum++;
        }

        if (collision.gameObject.tag == "Item")
        {
            //Gets ClothesPlacement's itemholder then connects it to the index of the positions in clothing spots
            GameObject shirt = GameObject.Find("Shirt");
            ClothesPlacement placement = shirt.GetComponent<ClothesPlacement>();
            Transform assignment = placement.itemHolder;

            // Adds gameobject into list
            clothing.Add(collision.gameObject);

            // Sets collided object into the positions in the clothingSpots list
            shirt.transform.parent = clothingSpots[indexNum].transform;
            shirt.transform.localPosition = Vector3.zero;

        }
    }
}
