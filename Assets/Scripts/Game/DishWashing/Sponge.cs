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
    [SerializeField] public float drainRate;
    public bool isUsingWater;

    [Header("UI")]
    [SerializeField] private GameObject WaterBasin;
    [SerializeField] private Image waterBar;

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        if (isUsingWater)
        {
            waterBar.fillAmount -= consumeWater / 15.0f * Time.deltaTime;

            Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

            if (waterBar.fillAmount != 0 && hit.collider != null)
            {
                dish = hit.collider.GetComponent<Dish>();
                dish.currentDirt -= drainRate * Time.deltaTime;
            }
            else return;
        }
        else
        {
            waterBar.fillAmount += waterFillRate / 10.0f * Time.deltaTime;
        }
    }
}
