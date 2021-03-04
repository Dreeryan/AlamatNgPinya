using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Transform  itemHolder;
    [Tooltip("Amount of distance required to trigger movement codes")]
    [SerializeField] private float      moveOffset = 1.2f;

    private Vector2 curMousePos;
    private Vector2 prevMousePos;
    private Vector2 returnPosition;

    public  Vector2 CurMousePos     => curMousePos;
    public  Vector2 PrevMousePos    => prevMousePos;
    public  Vector2 ReturnPosition  => returnPosition;

    public bool     HasMovedEnough  => Vector2.Distance(curMousePos, prevMousePos) >= moveOffset;

    [SerializeField] private bool canSnapbackToStart;

    void Start()
    {
        returnPosition = transform.position;
    }

    void OnMouseDrag()
    {
        if (GameManager.Instance.IsPaused) return;
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
        return Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= moveOffset &&
               Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= moveOffset;
    }
}
