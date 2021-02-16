using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TaskListManager : BaseManager<TaskListManager>
{
    [SerializeField] private TaskDatabase taskDB;

    private List<string> taskList = new List<string>();

    protected override void Start()
    {
        base.Start();
        GetTasksFromDataBase();
        //Get all tasks and put it in the list of this manager  

    }
    public string GetTask(string TaskId)
    {
        return taskDB.GetData(TaskId).GetTask();
    }

    public void RemoveTaskFromList(string TaskId)
    {
        string task = taskDB.GetData(TaskId).GetTask();

        for (int i = 0; i < taskList.Count; i++)
        {
            if (task == taskList[i]) taskList.Remove(taskList[i]);
        }
    }

    private void GetTasksFromDataBase()
    {
        for (int i = 0; i < taskDB.dataSet.Count; i++)
        {
            this.taskList.Add(taskDB.dataSet[i].GetTask());
            
        }
    }

}
