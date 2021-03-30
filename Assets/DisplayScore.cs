using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DisplayScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI uiText;
    // Start is called before the first frame update
    void OnEnable()
    {
        decimal timeAmount = ((decimal)TimerManager.Instance.CurTime);
        timeAmount = decimal.Round(timeAmount,2);

        uiText.text = "Time:" +  (timeAmount) +"s";
    }


}
