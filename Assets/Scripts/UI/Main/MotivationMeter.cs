using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotivationMeter : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private void OnEnable()
    {
        MotivationManager.OnMotivationUpdated += UpdateFillAmount;
    }

    private void OnDisable()
    {
        if (MotivationManager.IsShuttingDown) return;

        MotivationManager.OnMotivationUpdated -= UpdateFillAmount;
    }

    private void Start()
    {
        if (fillImage != null && MotivationManager.Instance != null)
            fillImage.fillAmount = MotivationManager.Instance.FillRatio;
    }

    private void UpdateFillAmount(float newVal)
    {

        if (!gameObject.activeSelf) return;
        if (fillImage == null) return;

        float oldVal = newVal + MotivationManager.Instance.Incrementation;

        //Tween from oldval to newval (wip)

        fillImage.fillAmount = newVal;
    }

}
