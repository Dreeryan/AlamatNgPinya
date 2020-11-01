using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stove : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] private TextMeshProUGUI temperatureText;
    [SerializeField] private float stoveTemperature;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Stove Slider").GetComponent<Slider>();
        temperatureText = GameObject.Find("Temperature Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdatePercent()
    {
        stoveTemperature = Mathf.RoundToInt(slider.value * 100);
    }

    void UpdateUI()
    {
        temperatureText.text = stoveTemperature.ToString("f0") + "°C";
    }
}
