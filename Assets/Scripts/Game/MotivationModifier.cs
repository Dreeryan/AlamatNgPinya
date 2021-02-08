using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationModifier : MonoBehaviour
{
    public enum MotivationType
    {
        Gain    = 0,
        Reduce  = 1
    }

    [SerializeField] private MotivationType type = MotivationType.Reduce;

    public void IncrementMotivation()
    {
        if (MotivationManager.Instance == null) return;

        MotivationManager manager = MotivationManager.Instance;

        if (MotivationManager.Instance.Data != null)
        {
            switch (type)
            {
                case MotivationType.Gain:
                    manager.IncrementMotivation(manager.Data.BaseGain);
                    break;
                case MotivationType.Reduce:
                    manager.IncrementMotivation(-manager.Data.BaseReduction);
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case MotivationType.Gain:
                    manager.IncrementMotivation(manager.defaultIncrementation);
                    break;
                case MotivationType.Reduce:
                    manager.IncrementMotivation(-manager.defaultIncrementation);
                    break;
            }
        }

    }
}
