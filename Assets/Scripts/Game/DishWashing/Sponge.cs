using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sponge : MonoBehaviour
{
    [SerializeField] Dish dish;

    private Vector2 mousePos;
    private Vector2 currentPosition;

    private bool isUsingWater;
    private bool isMouseDrag;

    [Header("Washing Variables")]
    [SerializeField] private float drainRate;
    [SerializeField] private float maxWater;
    [SerializeField] private float consumeWater;
    [SerializeField] private float waterFillRate;
    [SerializeField] private float consumeWaitTime;
    [SerializeField] private float fillWaitTime;


    private Vector2 previousPos = Vector2.zero;
    [SerializeField] private float dragTreshold = 0.01f;

    [Header("UI")]
    [SerializeField] GameObject WaterBasin;
    [SerializeField] Image waterBar;

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(previousPos, Input.mousePosition) >= dragTreshold)
        {
            if (isUsingWater)
            {
                waterBar.fillAmount -= consumeWater / consumeWaitTime * Time.deltaTime;

                if (waterBar.fillAmount != 0)
                {
                    dish.currentDirtRate -= drainRate * Time.deltaTime;
                }
                else return;
                previousPos = Input.mousePosition;
            }
            else
            {
                waterBar.fillAmount += waterFillRate / fillWaitTime * Time.deltaTime;
            }
        }
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        // The sponge will be back to its current position
        transform.position = currentPosition;

        isMouseDrag = false;
    }

    void OnMouseDown()
    {
        isMouseDrag = true;
        previousPos = Input.mousePosition;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the sponge is staying around the dish
        if (collision.gameObject.CompareTag("Dish"))
        {
            dish = collision.gameObject.GetComponent<Dish>();
            isUsingWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dish"))
        {
            isUsingWater = false;
        }
    }
}
