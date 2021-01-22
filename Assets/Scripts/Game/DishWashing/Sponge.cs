using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sponge : MonoBehaviour
{
    private Dish    dish;

    private Vector2 mousePos;
    private Vector2 currentPosition;
    private Vector2 previousPos = Vector2.zero;

    [Header("Sponge Settings")]
    [SerializeField] private float      drainRate;
    [SerializeField] private float      dragTreshold = 0.01f;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI    guideText;

    void Start()
    {
        currentPosition = transform.position;
        if (guideText != null) guideText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Vector2.Distance(previousPos, Input.mousePosition) >= dragTreshold)
        {
            //A: Nullcheck
            if (dish != null)
            {
                dish.ReduceDirtRate(drainRate * Time.deltaTime);
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
    }

    void OnMouseDown()
    {
        previousPos = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the collided object is a dirty dish
        if (collision.gameObject.GetComponent<Dish>() == null &&
            collision.gameObject.CompareTag("DirtyDish") == false) return;

        dish = collision.gameObject.GetComponent<Dish>();
        if (guideText != null) guideText.gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the exiting collision is the current dish
        if (collision.GetComponent<Dish>() && collision.gameObject == dish.gameObject)
        {
            dish = null;
        }
    }
}
