using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationModifier : MonoBehaviour
{
    [SerializeField] private int modifier;

    public void IncrementMotivation()
    {
        if (MotivationManager.Instance != null)
            MotivationManager.Instance.IncrementMotivation(modifier);
    }
}
