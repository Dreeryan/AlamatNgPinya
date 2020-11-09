using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] private GameObject objectTrigger;
    public UnityEvent OnObjectClick;

    private void OnMouseOver()
    {
        // Calls the event if object is clicked on;
        if (Input.GetMouseButtonDown(0)) OnObjectClick.Invoke();
    }

}
