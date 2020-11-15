using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanToy : MonoBehaviour
{
	//A: Dont do headers this way. Make it more specific (UI, Move Settings, etc)
    [Header("Variables")]
    [SerializeField] private float valueToTarget = 1.2f;
    [SerializeField] public Transform itemHolder;
    public bool isPlaced;
    public bool isMouseDown;
    public bool isPlayerNear;
    [SerializeField] private CarryController carryController;

    // Update is called once per frame
    void Update()
    {
        // If the object is near the item holder, the object will automatically be placed.
		//A: To make life easer, you can make this into a method that you can call instead
        if (Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= valueToTarget &&
            Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= valueToTarget)
        {
            ItemHolderPosition();
            isPlaced = true;
        }
        else
        {
            isPlaced = false;
        }

        if (isPlayerNear && isMouseDown)
        {
            carryController.PickupItem();
        }

    }
	
	/* //Can call this instead to reduce code length
	private bool IsValueUnderTarget(float initPos, float targetPos)
	{
		return (Mathf.Abs(initPos - targetPos)) <= valueToTarget;
	}
	*/

    public void ItemHolderPosition()
    {
        // To put the item in the holder.
        if (itemHolder != null)
            transform.position = itemHolder.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {	
		//A: Cleaner to do the opposite condition then return
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
			
			//A: Null check before accessing
            carryController = GameObject.FindGameObjectWithTag("Player").GetComponent<CarryController>();
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
}
