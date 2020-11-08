using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
    [SerializeField] private Sponge sponge;
    [SerializeField] private Transform dishRack;

    [Header("Variables")]
    [SerializeField] public float currentDirt;
    [SerializeField] public float drainRate;
    [SerializeField] private float minDirt;
    [SerializeField] private float valueToDeactivateGuide;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI dirtRateText;

    public bool isMouseDrag;

    // Start is called before the first frame update
    void Start()
    {
        if (dirtRateText == null) dirtRateText = GameObject.Find("Current dirt rate").GetComponent<TextMeshProUGUI>();

        if (dishRack == null)
            dishRack = GameObject.FindGameObjectWithTag("DishRack").transform;

        if (sponge == null)
            sponge = GameObject.FindGameObjectWithTag("Sponge").GetComponent<Sponge>();
    }

    void OnMouseDrag()
    {
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);
        if (hit.collider != null)
        {
            isMouseDrag = true;
            sponge.isUsingWater = true;

            if (dirtRateText != null)
            {
                dirtRateText.gameObject.SetActive(true);
                dirtRateText.text = "Current dirt rate: " + currentDirt.ToString("f0") + "%";
            }
        }
        else
        {
            sponge.isUsingWater = false;
        }

        if (currentDirt < minDirt)
        {
            currentDirt = minDirt;
            transform.position = dishRack.transform.position;
        }
    }

    void OnMouseUp()
    {
        isMouseDrag = false;
        sponge.isUsingWater = false;
        if (!isMouseDrag && dirtRateText != null)
        {
            dirtRateText.gameObject.SetActive(false);
        }
    }
}
