using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public UnityEvent OnShake;
    public Transform shakeObject;

    private bool    isMouseDrag;
    private Vector2 currentPosition;
    private Vector2 mousePos;
    private Vector2 previousPos = Vector2.zero;
    private float   threshold   = 0.1f;

    // This is for testing
    [SerializeField] private bool isShaking;

    void Update()
    {
        if (isMouseDrag)
            isShaking = true;

        else
            isShaking = false;

        if (isShaking)
            OnShake.Invoke();
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        isMouseDrag = true;
    }

    void OnMouseUp()
    {
        // The object will snap back to it's original position
        transform.position = currentPosition;

        isMouseDrag = false;
    }

    void OnMouseDown()
    {
        previousPos = Input.mousePosition;
    }


    public void Test()
    {
        Debug.Log("Shook");
    }
}