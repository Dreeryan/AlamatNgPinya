using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugIncrementMotivation : MonoBehaviour
{
    [SerializeField] private MotivationType type;
    [SerializeField] private KeyCode increaseKey =  KeyCode.PageUp;
    [SerializeField] private KeyCode decreaseKey =  KeyCode.PageDown;
    [SerializeField] private KeyCode ResetKey =     KeyCode.RightControl;

    private void Update()
    {
        if (Input.GetKeyDown(increaseKey)) 
        {
            type = MotivationType.Gain;
            IncrementMotivation();
        }
        else if (Input.GetKeyDown(decreaseKey)) 
        {
            type = MotivationType.Reduce;
            IncrementMotivation();
        }

        if (Input.GetKeyDown(ResetKey)) ResetMotivation();
    }

    void IncrementMotivation()
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager.Instance.UpdateMotivation(type);
    }

    void ResetMotivation()
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager.Instance.ResetMotivation();
    }
}
