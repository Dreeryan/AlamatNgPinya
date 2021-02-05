using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationManager : BaseManager<MotivationManager>
{
    [SerializeField] private int maxMotivation;

    private int currMotivation;

    public int MaxMotivation => maxMotivation;
    public int CurrMotivation => currMotivation;

    public float fillRatio => (float)currMotivation / (float)maxMotivation;

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

        OnMotivationUpdated?.Invoke(fillRatio);
    }

    public void ResetMotivation()
    {
        currMotivation = maxMotivation;
    }
}
