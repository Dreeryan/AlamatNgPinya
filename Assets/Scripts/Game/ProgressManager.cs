using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] 
    [Tooltip("How many tasks before the player wins")]
    private int progressChecks;

    private int progress;

    [Header("UI")]
    [SerializeField] 
    private GameObject winUI;

    private void Start()
    {
        if(winUI != null) winUI.SetActive(false);
    }

    public void AddProgress()
    {
        progress++;

        CheckProgress();
    }

    private void CheckProgress()
    {
        if (progress >= progressChecks)
        {
            if (winUI != null) winUI.SetActive(true);
        }
    }
}
