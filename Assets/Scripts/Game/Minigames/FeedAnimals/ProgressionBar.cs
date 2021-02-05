using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    [SerializeField] private Image      fillBar;
    [SerializeField] private GameObject WinScreen;

    public  bool  hasWon;

    private float maxAmount = 1;
    private float curAmount = 0;

    private void Start()
    {
        if (fillBar != null)
            fillBar.fillAmount = curAmount;

        if (WinScreen != null)
            WinScreen.SetActive(false);
    }

    private void Update()
    {
        if (fillBar.fillAmount >= maxAmount)
        {
            WinScreen.SetActive(true);
            hasWon = true;
        }
    }

    public void SetFood(int food)
    {
        fillBar.fillAmount = food;
    }

    public void AddFood()
    {
        fillBar.fillAmount += 1 * Time.deltaTime;
    }
}
