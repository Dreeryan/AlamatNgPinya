using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] GameObject object1;
    public UnityEvent OnObjectClick;

    private void OnMouseOver()
    {
        Debug.Log("Cursor above " + gameObject.name);
        if (Input.GetMouseButtonDown(0)) OnObjectClick.Invoke();
    }

}
