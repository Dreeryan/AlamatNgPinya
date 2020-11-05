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
        if (!isPlaced)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    void OnMouseUp()
    {
        // If the object is near the item holder, the object will automatically be placed.
        //A: Make this into a variable so design can adjust and easier to maintain
        if (Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= 1.2f &&
            Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= 1.2f)
        {
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
            isPlaced = true;
        }
        // Else, it will be placed back to it's last position
        else
        {
            //A: Directly assign instead of making new vector if possible. This can cause memory issues
            transform.position = new Vector2(currentPosition.x, currentPosition.y);

        }
    }
}
