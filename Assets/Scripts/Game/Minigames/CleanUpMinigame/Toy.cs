using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    public  bool    isPlaced;
    private bool    isHoveredOver;

    private bool    willBePickedUp;
    public  bool    WillBePickedUp => willBePickedUp;

    private void Start()
    {
        Counter counter = FindObjectOfType<Counter>();
        if (counter != null) counter.IncreaseGoalCount(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isHoveredOver)  willBePickedUp = true;
            else                willBePickedUp = false;
        }
    }

    private void OnMouseEnter()
    {
        isHoveredOver = true;
    }

    private void OnMouseExit()
    {
        isHoveredOver = false;
    }

    public void GetPickedUp(CarryController controller)
    {
        transform.parent = controller.ItemCarrier;
        transform.position = controller.ItemCarrier.position;
    }
}
