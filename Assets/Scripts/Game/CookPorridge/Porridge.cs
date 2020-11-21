using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Porridge : MonoBehaviour
{
    public Animator animator;
    private float currentTemp = 0.0f;
    private float addTemperature = 6.0f;
    private float decreaseTemperature = 6.0f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI tempText;
    [SerializeField] private GameObject winningPanel;

    [Header("Porridge Variables")]
    [SerializeField] private float coldTemp;
    [SerializeField] private float rightTemp;
    [SerializeField] private float hotTemp;
    [SerializeField] private GameObject fireObj;

    private bool isCold = false;
    private bool isRight = false;
    private bool isHot = false;

    // Start is called before the first frame update
    void Start()
    {
        if (fireObj != null) fireObj.SetActive(false);
        if (winningPanel != null) winningPanel.SetActive(false);
    }

    void Update()
    {
        UpdateTemp();

        if (isRight)
        {
            StartCoroutine("WinCountdown");
        }
        else
        {
            StopCoroutine("WinCountdown");
        }
    }

    public void UpdateTemp()
    {
        if (Input.GetMouseButton(0))
        {
            currentTemp += addTemperature * Time.deltaTime;

            if (currentTemp >= 100) currentTemp = 100;
        }

        else
        {
            currentTemp -= decreaseTemperature * Time.deltaTime;

            if (currentTemp <= 0) currentTemp = 0;
        }

        if (currentTemp > 0)
        {
            fireObj.SetActive(true);
            animator.SetBool("isCooking", true);
        }

        if (currentTemp < coldTemp)
        {
            isCold = true;
            isRight = false;
            isHot = false;
        }

        else if (currentTemp < rightTemp)
        {
            isRight = true;
            isCold = false;
            isHot = false;
        }

        else if (currentTemp < hotTemp)
        {
            isHot = true;
            isRight = false;
            isCold = false;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (tempText != null) tempText.text = currentTemp.ToString("f0") + "°C";
    }

    IEnumerator WinCountdown()
    {
        yield return new WaitForSeconds(3f);
        winningPanel.SetActive(true);
    }
}
