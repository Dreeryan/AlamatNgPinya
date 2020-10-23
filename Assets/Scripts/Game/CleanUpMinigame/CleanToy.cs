using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanToy : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] CarryController carryController;
    [SerializeField] public Transform itemHolder;
    public bool isPlaced;

    // Update is called once per frame
    void Update()
    {
        // If the object is near the item holder, the object will automatically be placed.
        if (Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= 1.2f &&
            Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= 1.2f)
        {
            ItemHolderPosition();
            isPlaced = true;
        }
        else
        {
            isPlaced = false;
        }
    }

    public void ItemHolderPosition()
    {
        // To put the item in the holder.
        transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
    }
}
