using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;

    private Vector2 mousePos;
    private Vector2 currentPosition;
    public  bool    isPlaced;

    void Start()
    {
        currentPosition = transform.position;
    }

    void OnMouseDrag()
    {
        // If the item is not yet placed while dragging, the item will be placed in the last position.
        if (!isPlaced)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

    }

    void OnMouseUp()
    {
        // If the object is near the item holder, the object will automatically be placed.
        if (Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= 1.2f &&
            Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= 1.2f)
        {
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
            isPlaced = true;
        }
        // Else, it will be placed back to it's last position
        else
        {
            transform.position = new Vector2(currentPosition.x, currentPosition.y);

        }
    }
}
