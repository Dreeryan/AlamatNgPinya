using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    [Header("Variables")]
    /*[SerializeField]
    private string objectTag;*/
    [SerializeField] private string minigameID;

    private bool            hasWon;
    public bool             HasWon => hasWon;

    [SerializeField]
    private int             objectGoal;
    public int              ObjectGoal => objectGoal;

    private int             curProgress;
    public int              CurProgress => curProgress;

    [Header("References")]
    public TextMeshProUGUI  counterText;

    [SerializeField] 
    private MotivationModifier motivationModifier;

    [SerializeField] 
    private UnityEvent      MinigameCompleted;

    // Start is called before the first frame update
    void Start()
    {
        hasWon = false;

        if (motivationModifier == null)
            motivationModifier = GetComponent<MotivationModifier>();
    }

    public void IncreaseGoalCount(int value)
    {
        objectGoal += value;
        if (counterText != null) UpdateDisplayText();
    }

    public void SetGoalCount(int value)
    {
        objectGoal = value;
        if (counterText != null) UpdateDisplayText();
    }

    public void IncreaseProgress(int value = 1)
    {
        if (hasWon) return;

        curProgress += value;
        if (curProgress > objectGoal) curProgress = objectGoal;
        if (counterText != null) UpdateDisplayText();

        if (curProgress >= objectGoal)
        {
            OnComplete();
        }
    }

    private void OnComplete()
    {
        hasWon = true;
        //Time.timeScale = 0.0f;
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
        counterText.text = "Collected: " + curProgress + " / " + objectGoal;
    }
}