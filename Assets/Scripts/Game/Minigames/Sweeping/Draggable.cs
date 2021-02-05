using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Transform  itemHolder;
    [SerializeField] private float      valueToTarget = 1.2f;

    private Vector2 curMousePos;
    public  Vector2 CurMousePos        => curMousePos;

    private Vector2 prevMousePos;
    public  Vector2 PrevMousePos    => prevMousePos;

    private Vector2 returnPosition;
    public  Vector2 ReturnPosition  => returnPosition;

    [SerializeField] private bool canSnapbackToStart;

    void Start()
    {
        returnPosition = transform.position;
    }

    void OnMouseDrag()
    {
        prevMousePos = curMousePos;
        curMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 maxScreen = new Vector3(Screen.width, Screen.height);
        Vector3 maxWorld = Camera.main.ScreenToWorldPoint(maxScreen);

        Vector3 minScreen = Vector3.zero;
        Vector3 minWorld = Camera.main.ScreenToWorldPoint(minScreen);

        curMousePos.y = Mathf.Clamp(curMousePos.y, minWorld.y, maxWorld.y);
        curMousePos.x = Mathf.Clamp(curMousePos.x, minWorld.x, maxWorld.x);
        transform.position = curMousePos;
    }

    void OnMouseUp()
    {
        // If the object is near the item holder, the object will automatically be placed.
        if (itemHolder != null && IsNearHolder())
        {
            transform.position = itemHolder.transform.position;
        }
        // Else, it will be placed back to it's last position
        else
        {
            // Snapback can be turned on or off in the Inspector
            if (canSnapbackToStart)
                transform.position = returnPosition;
        }
    }

    private bool IsNearHolder()
    {
        return Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= valueToTarget &&
               Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= valueToTarget;
    }
}
