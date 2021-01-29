using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseData
{
    [SerializeField] protected string id;

    public string ID => id;
}
