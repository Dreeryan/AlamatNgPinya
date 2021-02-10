using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    [SerializeField] private Image              fillBar;
    [SerializeField] private GameObject         WinScreen;
    [SerializeField] private MotivationModifier motivationModifier;
    public  bool  hasWon;

    private float maxAmount = 1;
    private float curAmount = 0;

    private void Start()
    {
        if (fillBar != null)
            fillBar.fillAmount = curAmount;

        if (WinScreen != null)
            WinScreen.SetActive(false);

        if (motivationModifier == null)
            motivationModifier = GetComponent<MotivationModifier>();
    }

    public void SetFood(int food)
    {
        fillBar.fillAmount = food;
    }

    public void AddFood()
    {
        fillBar.fillAmount += 1 * Time.deltaTime;

        if (fillBar.fillAmount >= maxAmount && !hasWon)
        {
            WinScreen.SetActive(true);
            hasWon = true;

            if (motivationModifier != null)
                motivationModifier.IncrementMotivation();
        }
    }
}
