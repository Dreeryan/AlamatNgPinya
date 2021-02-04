using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotivationMeter : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private void OnEnable()
    {
        MotivationManager.OnMotivationUpdated += OnMotivationUpdated;
    }

    private void OnDisable()
    {
        if (MotivationManager.IsShuttingDown) return;

        MotivationManager.OnMotivationUpdated -= OnMotivationUpdated;
    }

    private void OnMotivationUpdated(int newVal)
    {
        if (fillImage == null) return;

        fillImage.fillAmount = newVal;
    }
}
