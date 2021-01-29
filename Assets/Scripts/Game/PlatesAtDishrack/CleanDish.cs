using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDish : MonoBehaviour
{
    private Vector2             mousePos;
    private Vector2             returnPos;
    private bool                isPlaced        = false;
    private bool                isOverlapping   = false;
    private GameObject          dishRack;

    [Header("Rack Variables")]
    [SerializeField] private float distanceToRack = 1.2f;

    void Start()
    {
        returnPos = transform.position;
    }

    void OnMouseDrag()
    {
        if (isPlaced) return;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        if (isOverlapping)
        {
            transform.position = dishRack.transform.position;
            isPlaced = true;
        }
        else
        {
            transform.position = returnPos;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Dishrack>() &&
            !collision.GetComponent<Dishrack>().IsOccupied)
        {
            if (dishRack == null) dishRack = collision.gameObject;

            if (CheckDistance())
            {
                isOverlapping = true;
            }
        }
    }

    bool CheckDistance()
    {
        return Mathf.Abs(transform.position.x - dishRack.transform.position.x) <= distanceToRack &&
            Mathf.Abs(transform.position.y - dishRack.transform.position.y) <= distanceToRack;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Dishrack>())
        {
            dishRack = null;
            isOverlapping = false;
        }
    }
}