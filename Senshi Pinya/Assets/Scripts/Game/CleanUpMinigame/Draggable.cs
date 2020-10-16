using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] Transform itemHolder;

    private Vector2 mousePosition;
    private bool isPlaced;

    void OnMouseDown()
    {
        // If the item is not yet placed, the current position will still be the same
        if (!isPlaced)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    void OnMouseDrag()
    {
        // If the item is not yet placed while dragging, the current position will still be the same
        if (!isPlaced)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }

    void OnMouseUp()
    {
        // If the object is near the item holder, the object will automatically be placed.
        if (Mathf.Abs(transform.position.x - itemHolder.position.x) <= 1.2f && Mathf.Abs(transform.position.y - itemHolder.position.y) <= 1.2f)
        {
            isPlaced = true;
            transform.position = new Vector2(itemHolder.position.x, itemHolder.position.y);
        }
        else
        {
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }
}
