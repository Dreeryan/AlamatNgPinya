using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinSceneUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] UIElements;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlashUIElements());   
    }

    IEnumerator FlashUIElements()
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            yield return new WaitForSeconds(0.25f);

            UIElements[i].SetActive(true);
            //Tween scale each ui element

        }
    }
}
