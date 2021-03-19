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
        fillImage.fillAmount = MotivationManager.Instance.FillRatio + 0.2f;
        StartCoroutine(TweenToAmount());
    }

    IEnumerator TweenToAmount()
    {
        yield return new WaitForSeconds(1f);
        fillImage.DOFillAmount(MotivationManager.Instance.FillRatio, 1);
    }
}
