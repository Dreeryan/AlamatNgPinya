using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskData : BaseData
{
    [SerializeField] private string task;

    public string GetTask()
    {
        return this.task;

    }
}
