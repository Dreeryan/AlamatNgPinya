using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private string minigameID;

    [Header("References")]
    public TextMeshProUGUI counterText;

    [Header("UI Settings")]
    [Tooltip("Words before it shows progress, [phrase] : [current] / [goal] ")]
    [SerializeField]
    private string phrase;

    [SerializeField]
    private UnityEvent MinigameCompleted;

    void Start()
    {
        Debug.Log("minigameID: " + minigameID);
        WinCheck.Instance.Initialize(minigameID, MinigameCompleted);
    }

    public void UpdateDisplayText()
    {
        counterText.text = phrase + " : " + WinCheck.Instance.CurProgress + " / " + WinCheck.Instance.Goal;
    }
}