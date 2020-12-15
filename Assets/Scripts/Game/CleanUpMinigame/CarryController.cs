using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarryController : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private CleanToy cleanToy;

    [Header("Item Carrier")]
    [SerializeField] private Transform itemDetector;
    [SerializeField] private Transform itemCarrier;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI itemText;

    public bool isCarrying;

    void Start()
    {
        if (itemText != null) itemText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with the item
        if (collision.gameObject.CompareTag("Item"))
        {
            cleanToy = collision.gameObject.GetComponent<CleanToy>();

            itemText.gameObject.SetActive(true);
            itemText.text = "Left click the item to pickup";
            item = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Item")) return;
        {
            itemText.gameObject.SetActive(false);

            // If the item is placed and the player is far from the holder.
            if (cleanToy.isPlaced)
            {
                collision.gameObject.transform.parent = cleanToy.itemHolder;
                collision.gameObject.transform.position = cleanToy.itemHolder.position;

                if (collision.gameObject != null)
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    public void PickupItem()
    {
        isCarrying = true;
        item.gameObject.transform.parent = itemCarrier;
        item.gameObject.transform.position = itemCarrier.position;
		
		if (item.gameObject != null)
            item.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		
        if (cleanToy.isPlaced)
        {
            item.gameObject.transform.parent = cleanToy.itemHolder;
            item.gameObject.transform.position = cleanToy.itemHolder.position;

            if (item.gameObject != null)
                item.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            isCarrying = false;
        }
    }
}
