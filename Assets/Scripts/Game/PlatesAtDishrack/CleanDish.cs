using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDish : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 currentPosition;
    public bool isPlaced = false;
    private CircleCollider2D cd;

    [Header("Rack Variables")]
    [SerializeField] private GameObject dishRack;
    [SerializeField] private float distanceToRack = 1.2f;

    void Start()
    {
        currentPosition = transform.position;
        cd = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (isPlaced)
        {
            cd.enabled = false;
        }
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        if (isPlaced)
        {
            transform.position = dishRack.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rack"))
        {
            dishRack = collision.gameObject;

            if (Mathf.Abs(transform.position.x - dishRack.transform.position.x) <= distanceToRack &&
            Mathf.Abs(transform.position.y - dishRack.transform.position.y) <= distanceToRack)
            {
                isPlaced = true;
            }
        }
    }
}
