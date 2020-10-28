using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public UnityEvent OnShake;
    private Draggable draggableObject;

    void OnMouseDrag()
    {
        OnShake.Invoke();
        Debug.Log("Object shaking");
    }
}
