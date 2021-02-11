using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedHolder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Counter    counter;
    [SerializeField] private Image      fillBar;

    [SerializeField] private int        maxFeedValue;
    private float   curFeedValue = 0;

    public float    CurFeedValue    => curFeedValue;
    public float    FillRatio       => curFeedValue / (float)maxFeedValue;
    // Start is called before the first frame update
    void Start()
    {
        if (counter == null) counter = FindObjectOfType<Counter>();
        if (counter != null) counter.SetGoalCount(maxFeedValue);
    }

    public void IncreaseFeedCount(float value)
    {
        if (curFeedValue >= maxFeedValue) return;

        curFeedValue += value;

        curFeedValue = Mathf.Clamp(curFeedValue, 0, maxFeedValue);


        if (fillBar != null) fillBar.fillAmount = FillRatio;
        if (counter != null) counter.IncreaseProgress();
    }
}
