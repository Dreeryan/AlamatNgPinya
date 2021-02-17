using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TaskListUI : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup   objectivePanel;
    [SerializeField] private TextMeshProUGUI[] objectiveTexts; 

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
}
