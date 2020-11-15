using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarryController : MonoBehaviour
{
	//A: Dont do headers this way. Make it more specific (UI, Move Settings, etc)
    [Header("Variables")]
    [SerializeField] private CleanToy cleanToy;
    [SerializeField] private Transform itemDetector;
    [SerializeField] private Transform itemCarrier;
    [SerializeField] private GameObject item;

    [SerializeField] TextMeshProUGUI itemText;
    public bool isCarrying;

    void Start()
    {
		//A: This is dangerous. Someone can mess with the hierarchy and break this. Its a serialized field anyway so might as well remove it
		//Also avoid assigning every start. Do only if they are null
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
		//A: Cleaner to do if(!collision.gameObject.CompareTag("Item"))return;
        if (collision.gameObject.CompareTag("Item"))
        {
            itemText.gameObject.SetActive(false);
			//A: Dont have to add == true
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
		
		//A: Null check before accessing
        item.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		
		//A: Dont need == true
        if (cleanToy.isPlaced == true)
        {
            item.gameObject.transform.parent = cleanToy.itemHolder;
            item.gameObject.transform.position = cleanToy.itemHolder.position;
			
			//A: Null check before accessing
            item.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            isCarrying = false;
        }
    }
}
