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

    [SerializeField] private float maxWater = 100.0f;
    [SerializeField] private float consumeWater = 1.0f;
    [SerializeField] private float waterFillRate = 1.0f;
    [SerializeField] private float valueToDeactivateGuide = 4.0f;
    private bool isUsingWater;

    [Header("UI")]
    [SerializeField] private GameObject WaterBasin;
    [SerializeField] private Image waterBar;
    [SerializeField] private TextMeshProUGUI guideText;

    void Start()
    {
        currentPosition = transform.position;

        if (guideText != null) guideText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (isUsingWater)
        {
            waterBar.fillAmount -= consumeWater / 8.0f * Time.deltaTime;

            if (waterBar.fillAmount != 0)
            {
                dish.currentCleanRate += fillRate * Time.deltaTime;
            }
            else return;
        }
        else
        {
            waterBar.fillAmount += waterFillRate / 15.0f * Time.deltaTime;
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
            isUsingWater = true;
            StartCoroutine(DeactivateGuide());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dish"))
        {
            isUsingWater = false;
        }
    }

    IEnumerator DeactivateGuide()
    {
        yield return new WaitForSeconds(valueToDeactivateGuide);
        guideText.gameObject.SetActive(false);
    }
}
