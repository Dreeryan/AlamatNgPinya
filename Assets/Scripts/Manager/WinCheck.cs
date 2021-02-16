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
    public bool HasWon => hasWon;

    [Header("References")]
    private TextMeshProUGUI counterText;

    private MotivationModifier motivationModifier;

    private UnityEvent MinigameCompleted;

    public void Initialize(string _minigameID, int _goal, MotivationModifier _motivationModifier, UnityEvent _minigameCompleted)
    {
        hasWon = false;
        curProgress = 0;
        MinigameCompleted.RemoveAllListeners();

        minigameID = _minigameID;
        goal = _goal;
        motivationModifier = _motivationModifier;
        MinigameCompleted = _minigameCompleted;
    }

    public void IncreaseProgress(int value = 1)
    {
        if (hasWon) return;

        curProgress += value;
        if (curProgress > goal) curProgress = goal;
        if (counterText != null) UpdateDisplayText();

        if (curProgress >= goal) OnComplete();
    }

    private void OnComplete()
    {
        hasWon = true;
        motivationModifier.IncrementMotivation();
        MinigameCompleted?.Invoke();

        TimerManager.Instance.StopTimer();
        float score = ScoreManager.Instance.GetFinalScore(minigameID,
            TimerManager.Instance.CurTime);

        GameManager.Instance.UpdateScore(score);
        SceneLoader.Instance.LoadScene("WinScene", true);
    }

    private void UpdateDisplayText()
    {
        counterText.text = "Collected: " + curProgress + " / " + goal;
    }
}
