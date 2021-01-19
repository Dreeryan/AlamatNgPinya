using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] GameObject WinScreen;

    private float maxFood = 1;
    private float curFood = 0;

    private void Start()
    {
        bar.fillAmount = curFood;

        WinScreen.SetActive(false);
    }

    private void Update()
    {
        if (bar.fillAmount >= maxFood)
        {
            WinScreen.SetActive(true);
        }
    }

    public void SetFood(int food)
    {
        bar.fillAmount = food;
    }

    public void AddFood()
    {
        bar.fillAmount += 1 * Time.deltaTime;
    }
}
