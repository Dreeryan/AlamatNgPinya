using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedHolder : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private string minigameID;

    [Header("References")]
    [SerializeField] private Image      fillBar;

    [SerializeField] private int        maxFeedValue;
    private float   curFeedValue = 0;

    public float    CurFeedValue    => curFeedValue;
    public float    FillRatio       => curFeedValue / (float)maxFeedValue;

    void Start()
    {
        WinCheck.Instance.Initialize(minigameID, null);
        maxFeedValue = WinCheck.Instance.Goal;
    }

    public void IncreaseFeedCount(float value)
    {
        if (curFeedValue >= maxFeedValue) return;

        curFeedValue += value;

        curFeedValue = Mathf.Clamp(curFeedValue, 0, maxFeedValue);


        if (fillBar != null) fillBar.fillAmount = FillRatio;
        WinCheck.Instance.IncreaseProgress();
    }
}
