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

    [SerializeField] private string     objectTag;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        hasWon                      = false;

        if (winScreen != null) winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        curProgress++;
        if (curProgress > objectGoal) curProgress = objectGoal;
        if (counterText != null) UpdateDisplayText();

        CheckGoal();
    }

    private void UpdateDisplayText()
    {
        counterText.text = "Collected: " + curProgress + " / " + objectGoal;
    }

    void CheckGoal()
    {
        if (curProgress >= objectGoal)
        {
            hasWon = true;
            winScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void CheckForObjectsToCollect()
    {
        objectGoal = GameObject.FindGameObjectsWithTag(objectTag).Length;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    }
}