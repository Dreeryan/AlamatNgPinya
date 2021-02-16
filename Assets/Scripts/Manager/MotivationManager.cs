using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationManager : BaseManager<MotivationManager>
{
    [Header("Settings")]
    [Tooltip("Maximum motivation")]
    [SerializeField] private int maxMotivation;
    [Tooltip("Motivation required to do chores")]
    [SerializeField] private int reqMotivation;
    [Tooltip("Motivation gained or reduced when completing minigames")]
    [SerializeField] private int incrementation;
    private int currMotivation;

    public int MaxMotivation => maxMotivation;
    public int ReqMotivation => reqMotivation;
    public int Incrementation => incrementation;
    public int CurrMotivation => currMotivation;

    public float FillRatio => (float)currMotivation / (float)maxMotivation;

    public static System.Action<float> OnMotivationUpdated;

    protected override void Start()
    {
        base.Start();

        currMotivation = maxMotivation;
    }

    public void IncrementMotivation(int delta)
    {
        currMotivation += delta;

        currMotivation = Mathf.Clamp(currMotivation
            , 0
            , maxMotivation);

        OnMotivationUpdated?.Invoke(FillRatio);
    }

    public void ResetMotivation()
    {
        currMotivation = maxMotivation;
        OnMotivationUpdated?.Invoke(FillRatio);
    }

    public void EmptyMotivation()
    {
        currMotivation = 0;
        OnMotivationUpdated?.Invoke(FillRatio);
    }

    public bool HasEnoughMotivation()
    {
        if (currMotivation >= reqMotivation) return true;
        return false;
    }
}
