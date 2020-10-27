using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private CleanToy cleanToy;
    [SerializeField] private Transform itemDetector;
    [SerializeField] private Transform itemCarrier;

    void Start()
    {
        // Assigns the transform the child
        itemDetector = this.gameObject.transform.GetChild(0);
        itemCarrier = this.gameObject.transform.GetChild(1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with the item, the player will grab the item
        if (collision.gameObject.CompareTag("Item"))
        {
            cleanToy = collision.gameObject.GetComponent<CleanToy>();
			
			//A: You will want to make this into a method since you are doing the same sequence thrice
			//with minimal changes
            collision.gameObject.transform.parent = itemCarrier;
            collision.gameObject.transform.position = itemCarrier.position;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            // If the item is placed, the player will no longer hold the item.
            if (cleanToy.isPlaced == true)
            {
                collision.gameObject.transform.parent = cleanToy.itemHolder;
                collision.gameObject.transform.position = cleanToy.itemHolder.position;
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If the item is placed and the player is far from the holder.
        if (cleanToy.isPlaced == true)
        {
            collision.gameObject.transform.parent = cleanToy.itemHolder;
            collision.gameObject.transform.position = cleanToy.itemHolder.position;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
