using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationModifier : MonoBehaviour
{
    [SerializeField] private MotivationType type = MotivationType.Reduce;

    public void IncrementMotivation()
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager manager = MotivationManager.Instance;

        switch (type)
        {
            case MotivationType.Gain:
                manager.UpdateMotivation(MotivationType.Gain);
                break;
            case MotivationType.Reduce:
                manager.UpdateMotivation(MotivationType.Reduce);
                break;
        }       
    }
}
