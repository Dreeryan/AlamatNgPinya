using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private void OnEnable()
    {
        TimerManager.OnTimerUpdated += UpdateText;
    }

    private void OnDisable()
    {
        TimerManager.OnTimerUpdated -= UpdateText;
    }

    void UpdateText(float value)
    {
        if (timerText == null) return;

        timerText.text = value.ToString();
    }
}
