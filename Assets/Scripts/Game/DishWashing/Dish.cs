using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
    private Collider2D col;
    private Renderer rend;

    [SerializeField] private Sponge sponge;

    [Header("Sponge Variables")]
    [SerializeField] public float currentDirtRate;
    [SerializeField] private float minDirtRate = 0f;
    [SerializeField] private Transform cleanDishRack;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dirtRateText;

    public bool isPlaced;
    // Start is called before the first frame update
    void Start()
    {
        if (dirtRateText != null) dirtRateText.gameObject.SetActive(false);

        if (cleanDishRack != null)
        {
            cleanDishRack = GameObject.Find("CleanDishRack").transform;
        }

        col = GetComponent<Collider2D>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the current clean rate is equal to the max clean rate
        if (currentDirtRate < minDirtRate)
        {
            currentDirtRate = minDirtRate;
            transform.position = cleanDishRack.transform.position;
            isPlaced = true;

            rend.material.color = new Color32(225, 225, 225, 0);
            this.gameObject.transform.parent = cleanDishRack;
            if (dirtRateText != null) dirtRateText.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the dish is staying within the sponge
        if (collision.gameObject.CompareTag("Sponge"))
        {
            if (dirtRateText != null) dirtRateText.gameObject.SetActive(true);
            sponge = collision.gameObject.GetComponent<Sponge>();
            dirtRateText.text = "Current dirt rate: " + currentDirtRate.ToString("f0") + "%";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sponge"))
        {
            dirtRateText.gameObject.SetActive(false);
        }
    }
}
