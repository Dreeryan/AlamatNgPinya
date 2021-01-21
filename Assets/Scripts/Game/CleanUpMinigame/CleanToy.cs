using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanToy : MonoBehaviour
{
    [SerializeField] private CarryController carryController;
	//A: Dont serialize public variables. This is redundant
    [SerializeField] public Transform itemHolder;

    private Collider2D col2d;
	
	//A: Might be better to call this "Toy Bin Settings". Remember this is for designer who may not
	//have prog background
    [Header("Toy Bin Variables")]
    [SerializeField] private float distanceToToyBin = 1.2f;

    public bool isPlaced;
    public bool isMouseDown;
    public bool isPlayerNear;

    void Start()
    {
        col2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaceItem();

        if (isPlayerNear && isMouseDown)
        {
            carryController.PickupItem();
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
            isPlayerNear = true;
			
			
			//A: Indention
            if (carryController != null)
            carryController = GameObject.FindGameObjectWithTag("Player").GetComponent<CarryController>();
            //carryController = GameObject.Find("Player").GetComponent<CarryController>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void OnMouseDown()
    {
        isMouseDown = true;
    }

    public void PlaceItem()
    {
		//Make a generic function that returns the val to handle this so its shorter and cleaner
        if (Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= distanceToToyBin &&
            Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= distanceToToyBin)
        {
            ItemHolderPosition();
            isPlaced = true;
        }
        else
        {
            isPlaced = false;
        }
    }
}
