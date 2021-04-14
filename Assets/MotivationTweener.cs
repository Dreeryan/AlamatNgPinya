using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MotivationTweener : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    public float reductionValue;
    // Start is called before the first frame update
    void Start()
    {
        //Temporary fix
        if (SceneManager.GetActiveScene().name =="Tag" || SceneManager.GetActiveScene().name == "HideAndSeek")
        {

            fillImage.fillAmount = MotivationManager.Instance.FillRatio -0.2f;
            return;
        }

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
