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
			//A: Directly assign instead of making new vector if possible. This can cause memory issues
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Place all objectives that happen once trash is sweeped to specified area here
        if (collision.gameObject.tag == "Goal")
        {
            // Snaps the object into the specified area if it collides with it
			//A: Directly assign instead of making new vector if possible. This can cause memory issues
           transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
            isPlaced = true;
            
            if (trashCounter != null)
                // Adds a point to the trashCollected counter
				//A: Make sure this doesnt get double triggered especially at different FPS
                trashCounter.trashCollected = trashCounter.trashCollected + 1;
        }

        if (collision.gameObject.tag == "Blocker")
        {
            var force = transform.position - collision.transform.position;

            force.Normalize();

            // Pushes the object
            GetComponent<Rigidbody2D>().AddForce(force * pushStrength);
        }
    }
}
