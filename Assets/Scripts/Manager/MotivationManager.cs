using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum MotivationType
{
    Gain = 0,
    Reduce = 1
}

public class MotivationManager : BaseManager<MotivationManager>, ISavedData
{
    [SerializeField] private UnityEvent OnLowMotivation;
    [SerializeField] private UnityEvent OnEnoughMotivation;

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
        InitializeSavedData();
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
        SaveData();
    }

    public void ResetMotivation()
    {
        currMotivation = maxMotivation;
        OnMotivationUpdated?.Invoke(FillRatio);
        SaveData();
    }

    public void EmptyMotivation()
    {
        currMotivation = 0;
        OnMotivationUpdated?.Invoke(FillRatio);
        SaveData();
    }

    public bool HasEnoughMotivation()
    {
        if (currMotivation >= reqMotivation)
        {
            OnEnoughMotivation?.Invoke();
            return true; 
        }
        OnLowMotivation?.Invoke();
        return false;
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }

    public void InitializeSavedData()
    {
        if (!SaveManager.DoesFileExist("PlayerData"))
        {
            this.currMotivation = this.maxMotivation;
            return;
        }

        PlayerSave playerData = SaveManager.LoadData<PlayerSave>("PlayerData");
        currMotivation = playerData.savedMotivation;
    }

    public void SaveData()
    {
        SaveManager.Instance.playerSavedData.savedMotivation = this.currMotivation;
    }
}
