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
    private Vector2 previousPos = Vector2.zero;

    private bool isOnDish;
    private bool isMouseDrag;

    [Header("Washing Variables")]
    [SerializeField] private float drainRate;
    [SerializeField] private float dragTreshold = 0.01f;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI guideText;

    void Start()
    {
        currentPosition = transform.position;
        if (guideText != null) guideText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Vector2.Distance(previousPos, Input.mousePosition) >= dragTreshold)
        {
            if (isOnDish)
            {
				//A: Nullcheck
                dish.currentDirtRate -= drainRate * Time.deltaTime;
                previousPos = Input.mousePosition;
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
        if (collision.gameObject.CompareTag("DirtyDish"))
        {
            dish = collision.gameObject.GetComponent<Dish>();
            isOnDish = true;

            if (guideText != null)
            guideText.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DirtyDish"))
        {
            isOnDish = false;
        }
    }
}
