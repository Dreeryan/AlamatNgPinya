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
    public TextMeshProUGUI progressText;

    [SerializeField]
    private UnityEvent MinigameCompleted;

    void Start()
    {
        WinCheck.Instance.Initialize(minigameID, MinigameCompleted, progressText);
    }
}