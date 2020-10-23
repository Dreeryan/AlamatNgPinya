using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] CleanToy cleanToy;
    public Transform itemDetector;
    public Transform itemCarrier;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with the item, the player will grab the item
        if (collision.gameObject.CompareTag("Item"))
        {
            cleanToy = collision.gameObject.GetComponent<CleanToy>();
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
