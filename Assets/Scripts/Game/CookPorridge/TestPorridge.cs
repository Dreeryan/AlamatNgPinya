using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestPorridge : MonoBehaviour
{
    [SerializeField] private GameObject fireObj;
    public Animator animator;

    [SerializeField] private TextMeshProUGUI tempText;
    private float currentTemp = 0.0f;

    [SerializeField] private float addTemperature;
    [SerializeField] private float decreaseTemperature;
    [SerializeField] private float coldTemp;
    [SerializeField] private float cookTemp;
    [SerializeField] private float hotTemp;

    public bool isDown;
    public bool cold = false;
    public bool right = false;
    public bool hot = false;

    // Start is called before the first frame update
    void Start()
    {
        fireObj.SetActive(false);
    }

    void Update()
    {
        UpdateTemp();
    }

    public void UpdateTemp()
    {
        if (Input.GetMouseButton(0))
        {
            currentTemp += addTemperature * Time.deltaTime;

            if (currentTemp >= 100)
            {
                currentTemp = 100;
            }
        }

        else
        {
            currentTemp -= decreaseTemperature * Time.deltaTime;

            if (currentTemp <= 0)
            {
                currentTemp = 0;
            }
        }

        if (currentTemp > 0)
        {
            fireObj.SetActive(true);
            animator.SetBool("Cooking", true);
        }

        if (currentTemp < coldTemp)
        {
            //print("Cold temp");
            cold = true;
            right = false;
            hot = false;
        }

        else if (currentTemp < cookTemp)
        {
            //print("Right temp");
            right = true;
            cold = false;
            hot = false;
        }

        else if (currentTemp < hotTemp)
        {
            //print("Hot temp");
            hot = true;
            right = false;
            cold = false;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        tempText.text = currentTemp.ToString("f0") + "°C";
    }
}
