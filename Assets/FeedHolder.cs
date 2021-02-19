using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedHolder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image      fillBar;

    [SerializeField] private float        defaultFeedMax;
    private float   maxFeedValue = -1;
    private float   curFeedValue = 0;

    public float    CurFeedValue    => curFeedValue;
    public float    MaxFeedValue    => maxFeedValue;
    public float    FillRatio       => curFeedValue / maxFeedValue;

    public void IncreaseFeedCount(float value)
    {
        if (maxFeedValue == -1f)
            InitFeedGoal();

        if (curFeedValue >= maxFeedValue) return;

        float increaseValue = value * Time.deltaTime;

        curFeedValue += increaseValue;
        curFeedValue = Mathf.Clamp(curFeedValue, 0, maxFeedValue);

        if (fillBar != null) fillBar.fillAmount = FillRatio;

        WinCheck.Instance.IncreaseProgress(increaseValue);
    }

    void InitFeedGoal()
    {
        // Make sure maxFeedValue has been initialized
        if (WinCheck.Instance != null)
            maxFeedValue = WinCheck.Instance.Goal;
        else
            maxFeedValue = defaultFeedMax;
    }
}
