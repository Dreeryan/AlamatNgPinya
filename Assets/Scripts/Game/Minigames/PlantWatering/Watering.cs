using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Watering : MonoBehaviour
{
    [Header("Variables")]
    [Tooltip("The amount to be reached")]
    [SerializeField] private float maxFill = 100f;
    [Tooltip("How much will be added per second")]
    [SerializeField] private float fillRate = 20f;

    private float fillAmount;
    private bool isBucketOnMe;
    private bool isWatered;

    public bool IsWatered => isWatered;

    [Header("References")]
    [SerializeField] private Counter counter;
    [SerializeField] private Bucket bucket;

    [Header("UI")]
    [SerializeField] private GameObject fillBar;
    [SerializeField] private Image fillBarImage;

    [Header("Sprites")]
    [SerializeField] private Image plant;
    [SerializeField] private Sprite dryPlant;
    [SerializeField] private Sprite wateredPlant;

    [Header("Sound")]
    [SerializeField] private UnityEvent onFilling;
    [SerializeField] private UnityEvent onFillingStop;
    [SerializeField] private UnityEvent onWatered;

    void Start()
    {
        isWatered = false;

        // hide the bar at the start
        if (fillBar != null) fillBar.SetActive(false);

        // show the dry plant at the start
        if (dryPlant != null) plant.sprite = dryPlant;

        // null check
        if (fillBar == null) Debug.LogWarning("no object referenced for fillBar");
        if (fillBarImage == null) Debug.LogWarning("no object referenced for fillBarImage");
        if (bucket == null) Debug.LogWarning("no object referenced for bucket");
    }

    void Update()
    {
        if (bucket.GetisFilling() && isBucketOnMe && !isWatered)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("press");
                // play filling sound
                onFilling?.Invoke();
            }

            if(Input.GetMouseButtonUp(0))
            {
                onFillingStop?.Invoke();
            }

            // while it's not filled up
            if (fillAmount < maxFill)
            {
                // show bar when its the first time or when it's not yet full
                fillBar.SetActive(true);

                // increase the fill amount by fill rate
                fillAmount += fillRate * Time.deltaTime;

            }            

            // when it's filled up
            if (fillAmount >= maxFill)
            {
                // clamping of values
                fillAmount = maxFill;

                // set is watered
                isWatered = true;

                // hide the bar when its full
                if (fillBar != null) fillBar.SetActive(false);

                // show watered version of plant
                if (wateredPlant != null) plant.sprite = wateredPlant;

                // SFX
                onWatered?.Invoke();

                onFillingStop?.Invoke();

                // update bucket sprite
                bucket.UpdateSprite();

                // increase progress
                WinCheck.Instance.IncreaseProgress();
            }

            UpdateUI();
        }
    }

    public void SetIsBucketOnMe(bool p_isBucketOnMe)
    {
        isBucketOnMe = p_isBucketOnMe;
        bucket.SetCurrentPlant(this); 
    }

    void UpdateUI()
    {
        fillBarImage.fillAmount = fillAmount / maxFill;
    }
}
