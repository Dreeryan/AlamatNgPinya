using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private Transform eggBasket;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 mousePos;
    private Vector2 currentPosition;
    public bool isPlaced;

    void Start()
    {
        currentPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
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
            transform.position = new Vector2(eggBasket.transform.position.x, eggBasket.transform.position.y);
            isPlaced = true;
            rb.isKinematic = true;
        }
        // Else, it will be placed back to it's last position
        else
        {
            transform.position = new Vector2(currentPosition.x, currentPosition.y);
        }
    }
}
