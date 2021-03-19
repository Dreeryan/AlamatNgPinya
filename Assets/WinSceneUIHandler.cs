using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinSceneUIHandler : MonoBehaviour
{   
    [SerializeField] private GameObject[] uiElements;
    [SerializeField] private Vector2[] targetUIScale;
    [SerializeField] private float secondsToWait;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            targetUIScale[i] = uiElements[i].transform.localScale;
            uiElements[i].transform.localScale *= 0.15f;
            uiElements[i].SetActive(false);
        }
        StartCoroutine(FlashUIElements());
    }

    IEnumerator FlashUIElements()
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            yield return new WaitForSeconds(secondsToWait);

            uiElements[i].SetActive(true);
            uiElements[i].transform.DOScale(targetUIScale[i], 1);
            //Change code later if you have to
            if (i == 2) secondsToWait += 1;
            if (i == 3) secondsToWait -= 1;
            //Tween scale each ui element

        }
    }
}
