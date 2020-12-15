using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Porridge : MonoBehaviour
{
    private float currentTemp = 0.0f;
    private float maxTemp = 100.0f;
    private float rightTemp = 30f;
    private bool isRightTemp = false;

    [Header("Animator")]
    public Animator fireAnimator;
    public Animator potCoverAnimator;

    [Header("UI")]
    [SerializeField] private Slider porridgeSlider;
    [SerializeField] private GameObject winningPanel;

    [Header("Porridge Variables")]
    [SerializeField] private float addTemperature;
    [SerializeField] private float decreaseTemperature;
    [SerializeField] private float coldTemp;
    [SerializeField] private float cookTemp;
    [SerializeField] private float hotTemp;
    [SerializeField] private float secondsToUndercooked;
    [SerializeField] private float secondsToCooked;
    [SerializeField] private float secondsToWin;

    void Start()
    {
        if (winningPanel != null) winningPanel.SetActive(false);
    }

    void Update()
    {
        UpdateTemp();
        print(currentTemp);

        // If its at the right temp
        if (isRightTemp)
        {
            StartCoroutine("RightTempCountdown");
        }
        else
        {
            StopCoroutine("RightTempCountdown");
        }
    }

    public void UpdateTemp()
    {
        // Getting the current temp from the slider value
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

        if (currentTemp < 30)
        {
            //potCoverAnimator.SetBool("isFireOn", false);
        }

        if (currentTemp > rightTemp)
        {
            isRightTemp = true;
        }
        else
        {
            isRightTemp = false;
        }
    }

    IEnumerator RightTempCountdown()
    {
        yield return new WaitForSeconds(secondsToUndercooked);
        potCoverAnimator.SetBool("isFireOn", true);
        yield return new WaitForSeconds(secondsToCooked);
        potCoverAnimator.SetBool("isCooked", true);
        yield return new WaitForSeconds(secondsToWin);
        winningPanel.SetActive(true);
    }
}
