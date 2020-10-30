using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public GameObject shaker;
    public UnityEvent OnShake;
    private Vector2 startPos;
    private Vector3 randomPos;
    private bool goingUp;

    void Update()
    {
        Shaking();
    }

    void OnMouseDrag()
    {
        OnShake.Invoke();
        Debug.Log("Object shaking");
    }

    void Shaking()
    {
        if (goingUp)
        {
            transform.Translate(0, 0.1f, 0);
            goingUp = false;
        }

        else
        {
            transform.Translate(0, -0.1f, 0);
            goingUp = true;
        }
    }

}
