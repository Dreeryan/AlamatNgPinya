using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI  counterText;

    private bool            hasWon;
    public bool             HasWon => hasWon;

    private int             objectGoal;
    public int              ObjectGoal => objectGoal;
    private int             curProgress;
    public int              CurProgress => curProgress;

    [SerializeField] private string             objectTag;
    [SerializeField] private GameObject         winScreen;
    [SerializeField] private MotivationModifier motivationModifier;

    // Start is called before the first frame update
    void Start()
    {
        hasWon = false;

        if (winScreen != null)
            winScreen.SetActive(false);

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

        if (HasReachedGoal())
        {
            hasWon = true;
            winScreen.SetActive(true);
            Time.timeScale = 0.0f;
            motivationModifier.IncrementMotivation();
        }
    }

    private void UpdateDisplayText()
    {
        counterText.text = "Collected: " + curProgress + " / " + objectGoal;
    }

    bool HasReachedGoal()
    {
        if (curProgress >= objectGoal) return true;
        return false;
    }

    public void CheckForObjectsToCollect()
    {
        objectGoal = GameObject.FindGameObjectsWithTag(objectTag).Length;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    }
}