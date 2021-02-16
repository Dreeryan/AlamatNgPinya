using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TemporaryObjectivesUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUI;  
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
        UpdateText();
        TaskListManager.Instance.onTaskRemoved.AddListener(UpdateText);


    }

    void UpdateText()
    {
        Debug.Log("update text");
        textMeshProUI.text= "You have " + TaskListManager.Instance.taskList.Count.ToString() + " tasks";
    }
}
