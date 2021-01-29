using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDatabase<T> : ScriptableObject where T : BaseData
{
    public List<T> dataSet;

    public T GetData(string id)
    {
        if(!dataSet.Exists(obj => obj.ID == id))
        {
            Debug.LogErrorFormat("No {0} found!", id);
            return null;
        }

        return dataSet.Find(obj => obj.ID == id);
    }
}
