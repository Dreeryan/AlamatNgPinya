using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    public bool     isPlaced;
    private bool    isSelected;

    private bool    willBePickedUp;
    public bool     WillBePickedUp
    {
        get { return willBePickedUp; }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isSelected)     willBePickedUp = true;
            else                willBePickedUp = false;
        }
    }

    private void OnMouseEnter()
    {
        isSelected = true;
    }

    private void OnMouseExit()
    {
        isSelected = false;
    }

    public void GetPickedUp(CarryController controller)
    {
        transform.parent = controller.ItemCarrier;
        transform.position = controller.ItemCarrier.position;
    }
}
