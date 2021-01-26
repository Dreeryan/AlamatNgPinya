using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarryController : MonoBehaviour
{
    private Toy overlappedToy;
    private Toy carriedToy;

    [Header("Item Carrier")]
    [SerializeField] private Transform  itemCarrier;
    public Transform                    ItemCarrier
    {
        get { return itemCarrier;  }
    }

    [Header("UI")]
    [SerializeField] TextMeshProUGUI    itemText;

    #region TempFix
    [SerializeField] private Counter    toyBin;
    #endregion

    private bool    isCarrying = false;
    public bool     IsCarrying
    {
        get { return isCarrying; }
    }

    void Start()
    {
        if (itemText != null) itemText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (toyBin != null && collision.gameObject.CompareTag("Goal"))
        {
            if (isCarrying) DropToy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Toy>())
        {
            if (isCarrying) return;

            overlappedToy = collision.gameObject.GetComponent<Toy>();

            if (overlappedToy.WillBePickedUp)
            {
                PickupToy();
            }
            else
            {
                itemText.gameObject.SetActive(true);
                itemText.text = "Left click the item to pickup";
            }
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Toy>()) return;
        
        itemText.gameObject.SetActive(false);
        overlappedToy = null;




        // If the item is placed and the player is far from the holder.
        //if (carriedToy.isPlaced)
        //{
        //    collision.gameObject.transform.parent = carriedToy.itemHolder;
        //    collision.gameObject.transform.position = carriedToy.itemHolder.position;

        //    if (collision.gameObject != null)
        //        collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        //}
        
    }

    public void PickupToy()
    {
        isCarrying = true;
        carriedToy = overlappedToy;

        carriedToy.gameObject.transform.parent = itemCarrier;
        carriedToy.gameObject.transform.position = itemCarrier.position;

        itemText.gameObject.SetActive(false);
    }

    void DropToy(GameObject bin)
    {
        carriedToy.transform.parent = bin.transform;
        carriedToy.transform.position = bin.transform.position;

        isCarrying = false;
        toyBin.objectsCollected++;

        itemText.gameObject.SetActive(false);
    }
}
