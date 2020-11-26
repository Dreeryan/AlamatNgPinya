using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Porridge : MonoBehaviour
{
    public Animator fireAnimator;
    public Animator potCoverAnimator;

    private float currentTemp = 0.0f;
    private float maxTemp = 100.0f;
    private int tempValue;

    [Header("UI")]
    [SerializeField] private Slider porridgeSlider;
    
    [Header("Porridge Variables")]
    [SerializeField] private float addTemperature;
    [SerializeField] private float decreaseTemperature;
    [SerializeField] private float coldTemp;
    [SerializeField] private float cookTemp;
    [SerializeField] private float hotTemp;

    public bool cold = false;
    public bool right = false;
    public bool hot = false;

    void Update()
    {
        UpdateTemp();
    }

    public void UpdateTemp()
    {
        currentTemp = (int)(porridgeSlider.value * 100);

        if (Input.GetMouseButton(0))
        {
            porridgeSlider.value += addTemperature * Time.deltaTime;

            if (currentTemp >= maxTemp)
            {
                currentTemp = maxTemp;
            }
        }

        else
        {
            porridgeSlider.value -= decreaseTemperature * Time.deltaTime;

            if (currentTemp <= 0)
            {
                currentTemp = 0;
            }
        }

        fireAnimator.SetFloat("Temp", currentTemp);
        potCoverAnimator.SetFloat("Temp", currentTemp);

        if (currentTemp > 0)
        {
            fireAnimator.SetBool("isFireOn", true);
            potCoverAnimator.SetBool("isFireOn", true);
        }
        else
        {
            fireAnimator.SetBool("isFireOn", false);
            potCoverAnimator.SetBool("isFireOn", false);
        }
    }
}
