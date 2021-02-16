using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TaskListManager : BaseManager<TaskListManager>
{
    [SerializeField] private TaskDatabase taskDB;

    public string GetTask(string TaskId)
    {
        return taskDB.GetData(TaskId).GetTask();
    }

    public void RemoveTaskFromList(string TaskId)
    {

    }

}
