using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Sponge : MonoBehaviour
{
    [SerializeField] private UnityEvent OnScrubbingDish;

    private Dish        dish;
    private Draggable   draggable;

    [Header("Sponge Settings")]
    [SerializeField] private float      drainRate;
    [SerializeField] private float      dragTreshold = 0.01f;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI    guideText;

    void Start()
    {
        draggable = GetComponent<Draggable>();

        if (guideText != null) guideText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Vector2.Distance(draggable.PrevMousePos,
            draggable.CurMousePos) >= dragTreshold && dish != null)
        {
            OnScrubbingDish?.Invoke();
            dish.ReduceDirtRate(drainRate * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the collided object is a dirty dish
        if (collision.gameObject.GetComponent<Dish>() == null) return;

        dish = collision.gameObject.GetComponent<Dish>();
        if (guideText != null) guideText.gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the exiting collision is the current dish
        if (collision.GetComponent<Dish>() && 
            collision.gameObject == dish.gameObject)
        {
            dish = null;
        }
    }
}
