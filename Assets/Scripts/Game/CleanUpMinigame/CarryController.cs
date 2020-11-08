using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarryController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private CleanToy cleanToy;
    [SerializeField] private Transform itemDetector;
    [SerializeField] private Transform itemCarrier;
    [SerializeField] GameObject item;

    [SerializeField] TextMeshProUGUI itemText;
    public bool isCarrying;

    void Start()
    {
        // Assigns the transform the child
        itemDetector = this.gameObject.transform.GetChild(0);
        itemCarrier = this.gameObject.transform.GetChild(1);
        if (itemText != null) itemText.gameObject.SetActive(false);
        cleanToy = GameObject.FindGameObjectWithTag("Item").GetComponent<CleanToy>();
    }

    void Update()
    {
      
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
        if (collision.gameObject.CompareTag("Item"))
        {
            itemText.gameObject.SetActive(false);
            // If the item is placed and the player is far from the holder.
            if (cleanToy.isPlaced == true)
            {
                collision.gameObject.transform.parent = cleanToy.itemHolder;
                collision.gameObject.transform.position = cleanToy.itemHolder.position;

                //A: Null check before accessing
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    public void PickupItem()
    {
        isCarrying = true;
        item.gameObject.transform.parent = itemCarrier;
        item.gameObject.transform.position = itemCarrier.position;
        item.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

        if (cleanToy.isPlaced == true)
        {
            item.gameObject.transform.parent = cleanToy.itemHolder;
            item.gameObject.transform.position = cleanToy.itemHolder.position;
            item.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            isCarrying = false;
        }
    }
}
