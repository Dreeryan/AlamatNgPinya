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

    [Header("Variables")]
    [SerializeField] float drainRate;
    [SerializeField] float maxWater;
    [SerializeField] float consumeWater;
    [SerializeField] float waterFillRate;
    public bool isUsingWater;

    [Header("UI")]
    [SerializeField] GameObject WaterBasin;
    [SerializeField] Image waterBar;

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        if (isUsingWater)
        {
			//A: What is 12 and 10? Make those into variables
            waterBar.fillAmount -= consumeWater / 12.0f * Time.deltaTime;

            if (waterBar.fillAmount != 0)
            {
                dish.currentDirtRate -= drainRate * Time.deltaTime;
            }
            else return;

        }
        else
        {
            waterBar.fillAmount += waterFillRate / 10.0f * Time.deltaTime;
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
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the sponge is staying around the dish
        if (collision.gameObject.CompareTag("Dish"))
        {
            dish = collision.gameObject.GetComponent<Dish>();

            //A: Null check

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
