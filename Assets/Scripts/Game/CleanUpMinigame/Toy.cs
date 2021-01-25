using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    public Transform itemHolder;

    [Header("Toy Bin Settings")]
    [Tooltip("Distance the toy can be before triggering the toy box")]
    [SerializeField] private float binDistOffset = 1.2f;

    public bool     isPlaced;
    public bool     isMouseDown;

    private bool    willBePickedUp;
    public bool     WillBePickedUp
    {
        get { return willBePickedUp; }
    }
    private bool    canBePickedUp;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canBePickedUp)  willBePickedUp = true;
            else                willBePickedUp = false;
        }
    }
	
    public void ItemHolderPosition()
    {
        // To put the item in the holder.
        if (itemHolder != null)
            transform.position = itemHolder.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canBePickedUp = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canBePickedUp = false;
        }
    }

    private void OnMouseEnter()
    {
        canBePickedUp = true;
    }

    private void OnMouseExit()
    {
        canBePickedUp = false;
    }

    public void GetPickedUp(CarryController controller)
    {
        transform.parent = controller.ItemCarrier;
        transform.position = controller.ItemCarrier.position;
    }

    public void PlaceItem()
    {
        //if (CloseToToyBin())
        //{
        //    ItemHolderPosition();
        //    isPlaced = true;
        //}
        //else
        //{
        //    isPlaced = false;
        //}
    }

    private bool CloseToToyBin()
    {
        Vector2 dist = new Vector2(Mathf.Abs(transform.position.x - itemHolder.transform.position.x)
            , Mathf.Abs(transform.position.y - itemHolder.transform.position.y));

        return dist.magnitude <= binDistOffset;
    }
}
