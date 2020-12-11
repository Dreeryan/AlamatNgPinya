using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] GameObject WinScreen;

    private int maxFood = 100;

    private void Start()
    {
        WinScreen.SetActive(false);
    }

    private void Update()
    {
        if (slider.value >= maxFood)
        {
            WinScreen.SetActive(true);
        }
    }

    public void SetFood(int food)
    {
        slider.value = food;
    }

    public void AddFood()
    {
        slider.value++;
    }
}
