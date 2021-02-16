using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class WinCheck : BaseManager<WinCheck>
{
    [SerializeField] private ScoreDatabase data;

    private string minigameID;
    private int goal;
    private int curProgress;
    private bool hasWon;

    public int Goal => goal;
    public int CurProgress => curProgress;
    public bool HasWon => hasWon;

    private MotivationType motivationType;
    private UnityEvent minigameCompleted;

    public void Initialize(string _minigameID, UnityEvent _minigameCompleted)
    {
        Debug.Log("enter initialization with values: " + _minigameID + " and " + _minigameCompleted);

        hasWon = false;
        curProgress = 0;
        minigameCompleted?.RemoveAllListeners();

        Debug.Log("values reset");

        minigameID = _minigameID;
        ScoreData scoreData = Instance.data.GetData(_minigameID);
        goal = scoreData.Goal;
        motivationType = scoreData.MotivationType;
        minigameCompleted = _minigameCompleted;

        Debug.Log("Done initialization");
    }

    public void IncreaseProgress(int value = 1)
    {
        if (hasWon) return;

        curProgress += value;
        if (curProgress > goal) curProgress = goal;

        if (curProgress >= goal) OnComplete();
    }

    private void OnComplete()
    {
        hasWon = true;

        TimerManager.Instance.StopTimer();
        float score = ScoreManager.Instance.GetFinalScore(minigameID,
            TimerManager.Instance.CurTime);

        MotivationManager.Instance.UpdateMotivation(motivationType);
        minigameCompleted?.Invoke();

        GameManager.Instance.UpdateScore(score);
        SceneLoader.Instance.LoadScene("WinScene", true);
    }
}
