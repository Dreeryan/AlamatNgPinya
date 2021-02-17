using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotivationType
{
    Gain = 0,
    Reduce = 1
}

public class MotivationManager : BaseManager<MotivationManager>, IManager
{
    [Header("Settings")]
    [Tooltip("Maximum motivation")]
    [SerializeField] private int maxMotivation;
    [Tooltip("Motivation required to do chores")]
    [SerializeField] private int reqMotivation;
    [Tooltip("Motivation gained or reduced when completing minigames")]
    [SerializeField] private int incrementation;

    [SerializeField] private int currMotivation;

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

    public void LoadData(PlayerSave loadedData)
    {
        currMotivation = loadedData.savedMotivation;
    }

    public void UpdateMotivation(MotivationType type)
    {
        int delta = incrementation;
        if (type == MotivationType.Reduce) delta *= -1;
        currMotivation += delta;

        currMotivation = Mathf.Clamp(currMotivation
            , 0
            , maxMotivation);

        OnMotivationUpdated?.Invoke(FillRatio);

        SaveManager.PlayerData.savedMotivation = currMotivation;

        SaveManager.SavePlayer();
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
