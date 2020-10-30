using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private GameObject     broom;
    [SerializeField] private float          pushStrength;
    [SerializeField] private Transform      itemHolder;
    [SerializeField] private TrashCounter   trashCounter;

    private bool isPlaced;

    public void Update()
    {
        transform.position.Normalize();
        
        if (broom != null)
            broom.transform.position.Normalize();

        if (isPlaced == true)
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Place all objectives that happen once trash is sweeped to specified area here
        if (collision.gameObject.tag == "Goal")
        {
            // Snaps the object into the specified area if it collides with it
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
            isPlaced = true;
            
            if (trashCounter != null)
                // Adds a point to the trashCollected counter
                trashCounter.trashCollected = trashCounter.trashCollected + 1;

            Debug.Log("Sweeped to the right spot");
        }
    }
}
