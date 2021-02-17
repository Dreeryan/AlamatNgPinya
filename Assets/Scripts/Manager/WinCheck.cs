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
    private TextMeshProUGUI progressText;
    private string phrase;
    private UnityEvent minigameCompleted;

    public void Initialize(string _minigameID, UnityEvent _minigameCompleted, TextMeshProUGUI _progressText = null)
    {
        hasWon = false;
        curProgress = 0;
        minigameCompleted?.RemoveAllListeners();

        minigameID = _minigameID;
        ScoreData scoreData = Instance.data.GetData(_minigameID);
        goal = scoreData.Goal;
        phrase = scoreData.Phrase;
        progressText = _progressText;
        motivationType = scoreData.MotivationType;
        minigameCompleted = _minigameCompleted;
    }

    public void IncreaseProgress(int value = 1)
    {
        Debug.Log("ProgressIncresed");

        if (hasWon) return;

        curProgress += value;

        if (curProgress > goal) curProgress = goal;
        UpdateDisplayText();

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

    private void UpdateDisplayText()
    {
        if(progressText != null)
            progressText.text = phrase + " : " + curProgress + " / " + goal;
    }
}
