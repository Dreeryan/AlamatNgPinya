using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sponge : MonoBehaviour
{
    [SerializeField] private Dish dish;

    private Vector2 mousePos;
    private Vector2 currentPosition;

    [Header("Variables")]
    [SerializeField] private float fillRate = 10.0f;

    void Start()
    {
        currentPosition = transform.position;
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        // The sponge will be back to its current position
        transform.position = new Vector2(currentPosition.x, currentPosition.y);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the sponge is staying around the dish
        if (collision.gameObject.CompareTag("Dish"))
        {
            dish = collision.gameObject.GetComponent<Dish>();
            dish.currentCleanRate += fillRate * Time.deltaTime;
        }
    }
}
