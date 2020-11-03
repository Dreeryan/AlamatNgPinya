using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watering : MonoBehaviour
{
    [Header("Variables")]
    [Tooltip("The amount to be reached")]
    [SerializeField] private float maxFill = 100f;
    [Tooltip("How much will be added per second")]
    [SerializeField] private float fillRate = 20f;

    private float fillAmount;
    private bool isFilling;

    [Header("UI")]
    [SerializeField] private GameObject fillBar;
    [SerializeField] private Image fillBarImage;

    [Header("Sprites")]
    [SerializeField] private Image plant;
    [SerializeField] private Sprite dryPlant;
    [SerializeField] private Sprite wateredPlant;
    
    void Start()
    {
        // hide the bar at the start
		if (fillBar != null) fillBar.SetActive(false);

        // show the dry plant at the start
        if (dryPlant != null) plant.sprite = dryPlant;

        // null check
        if (fillBar == null) Debug.LogWarning("no object referenced for fillBar");
        if (fillBarImage == null) Debug.LogWarning("no object referenced for fillBarImage");

        // setting the default value of the boolean for toggling
        isFilling = false;
    }

    void Update()
    {
        if (isFilling)
        {
            // increase the fill amount by fill rate
            if (fillAmount < maxFill) fillAmount += fillRate * Time.deltaTime;

            // when it's filled up
            if (fillAmount > maxFill)
            {
                // clamping of values
                fillAmount = maxFill;

                // hide the bar when its full
                if (fillBar != null) fillBar.SetActive(false);

                // show watered version of plant
                if (wateredPlant != null) plant.sprite = wateredPlant;
            }

            UpdateUI();
        }
    }

    public void ToggleFill()
    {
        // show bar when its the first time or when it's not yet full
        if (fillAmount < maxFill) fillBar.SetActive(true);

        // toggle the boolean
        isFilling = !isFilling;
    }

    void UpdateUI()
    {
        fillBarImage.fillAmount = fillAmount / maxFill;
    }
}
