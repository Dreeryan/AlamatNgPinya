using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class TaskListUI : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup   objectivePanel;
    [SerializeField] private TextMeshProUGUI[] objectiveTexts;
    [SerializeField] private Image pineappleTransformerMeter;
    [SerializeField] private PineappleTransformer pineappleTransformerObj;

    private TaskListManager taskListManagerObj;
    // Start is called before the first frame update
    void Start()
    {
        taskListManagerObj = TaskListManager.Instance;
    }

    public void UpdateTaskList()
    {
        //Enable the remaining objectives and set texts for them everytime player asks
        for (int i = 0; i < taskListManagerObj.taskList.Count; i++)
        {
            objectiveTexts[i].gameObject.SetActive(true);
            objectiveTexts[i].text = taskListManagerObj.taskList[i];
        }
    }

    public void UpdatePineappleMeter()
    {
        Debug.Log("Subtracted");
        float fillDifference = (float) ((double)pineappleTransformerMeter.fillAmount - (double) (1 /(double) pineappleTransformerObj.maxNumberToAsk));
        Debug.Log((double)(1 / (double)pineappleTransformerObj.maxNumberToAsk));
        Debug.Log(fillDifference);
        pineappleTransformerMeter.DOFillAmount(fillDifference, 0.5f);
    }
}
