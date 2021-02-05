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

    private void Start()
    {
        if (fillImage != null && MotivationManager.Instance != null)
            fillImage.fillAmount = MotivationManager.Instance.fillRatio;
    }

    private void OnMotivationUpdated(float newVal)
    {
        if (fillImage == null) return;

        fillImage.fillAmount = newVal;
    }

}
