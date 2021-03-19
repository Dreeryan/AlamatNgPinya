using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MotivationTweener : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    public float reductionValue;
    // Start is called before the first frame update
    void Start()
    {
        if (MotivationManager.Instance.CurrMotivation <= 0) return;
        fillImage.fillAmount = MotivationManager.Instance.FillRatio + 0.2f;
    }

    private void OnEnable()
    {
        StartCoroutine(TweenToAmount());
    }

    // There's a bug that doesn't work for incrementing motivation, fix later
    IEnumerator TweenToAmount()
    {
        yield return new WaitForSeconds(1f);
        fillImage.DOFillAmount(MotivationManager.Instance.FillRatio, 1);
    }
}
