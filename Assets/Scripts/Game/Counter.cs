using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private string objectTag;

    private bool            hasWon;
    public bool             HasWon => hasWon;

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

    public void IncreaseProgress()
    {
        if (hasWon) return;

        curProgress++;
        if (curProgress > objectGoal) curProgress = objectGoal;
        if (counterText != null) UpdateDisplayText();

        if (curProgress >= objectGoal)
        {
            hasWon = true;
            Time.timeScale = 0.0f;
            motivationModifier.IncrementMotivation();
            MinigameCompleted?.Invoke();

            SceneLoader.Instance.ChangeScene("WinScene", true);
        }
    }

    private void UpdateDisplayText()
    {
        counterText.text = "Collected: " + curProgress + " / " + objectGoal;
    }
}