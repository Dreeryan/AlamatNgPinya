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
        float timeAmount = TimerManager.Instance.CurTime;

        uiText.text = "Time:" +  (timeAmount.ToString("0.00")) +"s";
    }


}
