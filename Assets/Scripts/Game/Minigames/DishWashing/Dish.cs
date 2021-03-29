using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
    [SerializeField] private UnityEvent onDishCleaned;
    [SerializeField] public UnityEvent<Dish> onActivateNextDish;
    public UnityEvent OnDishCleaned => onDishCleaned;

    [Header("Dish Settings")]
    [SerializeField] private float maxDirtRate = 100f;
    [SerializeField] private float minDirtRate = 0f;
    [SerializeField] private Transform cleanDishRack;
    [SerializeField] public Sprite cleanDishSprite;
    private float currentDirtRate = 0f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dirtRateText;

    private SpriteRenderer sRenderer;
    private Collider2D collider;
    public int index = 0;
    [SerializeField]private bool canBeCleaned;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();

        if (dirtRateText != null) 
            dirtRateText.gameObject.SetActive(false);

        if (cleanDishRack == null) 
            cleanDishRack = FindObjectOfType<CleanDishRack>().transform;

        currentDirtRate = maxDirtRate;
    }

    public void ReduceDirtRate(float drainRate)
    {
        if (!canBeCleaned) return;
        Debug.Log(this.currentDirtRate);
        currentDirtRate -= drainRate;
        if (currentDirtRate <= 0) OnCleaned();
    }

    public void EnableDish() 
    {
        canBeCleaned = true;
        if (sRenderer != null) sRenderer.enabled = true;
        if (collider != null) collider.enabled = true;
    }

    public void DisableDish()
    {
        if (sRenderer != null) sRenderer.enabled = false;
        if (collider != null) collider.enabled = false;
    }

    private void OnCleaned()
    {
        currentDirtRate = minDirtRate;

        transform.position = cleanDishRack.transform.position;

        transform.parent = cleanDishRack;
        if (dirtRateText != null) dirtRateText.gameObject.SetActive(false);
        onDishCleaned?.Invoke();
        onActivateNextDish?.Invoke(this);
        sRenderer.sprite = this.cleanDishSprite;
        collider.enabled = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the dish is staying within the sponge
        if (collision.GetComponent<Sponge>())
        {
            if (dirtRateText != null) dirtRateText.gameObject.SetActive(true);
            dirtRateText.text = "Current dirt rate: " + currentDirtRate.ToString("f0") + "%";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Sponge>())
        {
            dirtRateText.gameObject.SetActive(false);
        }
    }
}
