using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugIncrementMotivation : MonoBehaviour
{
    [SerializeField] private int incrementValue =   1;
    [SerializeField] private KeyCode increaseKey =  KeyCode.PageUp;
    [SerializeField] private KeyCode decreaseKey =  KeyCode.PageDown;
    [SerializeField] private KeyCode resetKey =     KeyCode.RightControl;
    [SerializeField] private KeyCode emptyKey =     KeyCode.RightShift;

    private void Update()
    {
        if (Input.GetKeyDown(increaseKey)) IncrementMotivation(incrementValue);
        if (Input.GetKeyDown(decreaseKey)) IncrementMotivation(-incrementValue);
        if (Input.GetKeyDown(resetKey)) ResetMotivation();
        if (Input.GetKeyDown(emptyKey)) EmptyMotivation();
    }

    void IncrementMotivation(int value)
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager.Instance.IncrementMotivation(value);
    }

    void ResetMotivation()
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager.Instance.ResetMotivation();
    }

    void EmptyMotivation()
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager.Instance.EmptyMotivation();
    }
}
