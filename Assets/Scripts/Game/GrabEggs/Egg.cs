using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private Transform eggBasket;

    private Vector2 mousePos;
    private Vector2 currentPosition;
    public bool isPlaced;

    void Start()
    {
        currentPosition = transform.position;
		//A: Finding via name is very risky and bug prone
        eggBasket = GameObject.Find("Egg Basket").transform;
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
        if (Mathf.Abs(transform.position.x - eggBasket.transform.position.x) <= 1.2f &&
            Mathf.Abs(transform.position.y - eggBasket.transform.position.y) <= 1.2f)
        {
            transform.position = eggBasket.transform.position;
            isPlaced = true;
        }
        // Else, it will be placed back to it's last position
        else
        {
            transform.position = currentPosition;
        }
    }
}
