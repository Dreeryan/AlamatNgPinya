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
        uiText.text = "Score:" + (int)ScoreManager.Instance.GetFinalScore(SceneManager.GetActiveScene().name, TimerManager.Instance.CurTime);
    }


}
