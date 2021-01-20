using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Transform  itemHolder;
    [SerializeField] private float      valueToTarget = 1.2f;

    private Vector2 mousePos;
    private Vector2 currentPosition;
    public  bool    isPlaced;
    public  bool    canSnapbackToStart;

    public ReturnIfVisionLost vision;

    void Start()
    {
        currentPosition = transform.position;
    }

    // Checks if object can be seen by the camera
    private void Update()
    {
        if (vision.isSeen == false && vision != null)
            transform.position = currentPosition;
    }

    void OnMouseDrag()
    {
        isPlaced = false;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 maxScreen = new Vector3(Screen.width, Screen.height);
        Vector3 maxWorld = Camera.main.ScreenToWorldPoint(maxScreen);

        Vector3 minScreen = Vector3.zero;
        Vector3 minWorld = Camera.main.ScreenToWorldPoint(minScreen);

        mousePos.y = Mathf.Clamp(mousePos.y, minWorld.y, maxWorld.y);
        mousePos.x = Mathf.Clamp(mousePos.x, minWorld.x, maxWorld.x);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        // If the object is near the item holder, the object will automatically be placed.
        if (Mathf.Abs(transform.position.x - itemHolder.transform.position.x) <= valueToTarget &&
            Mathf.Abs(transform.position.y - itemHolder.transform.position.y) <= valueToTarget)
        {
            transform.position = itemHolder.transform.position;
            isPlaced = true;
        }
        // Else, it will be placed back to it's last position
        else
        {
            // Snapback can be turned on or off in the Inspector
            if (canSnapbackToStart)
                transform.position = currentPosition;
        }
    }
}
