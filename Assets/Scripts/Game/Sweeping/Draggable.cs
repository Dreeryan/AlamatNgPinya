using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 currentPosition;
    public  bool    isPlaced;

    void Start()
    {
        currentPosition = transform.position;
    }

    public void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;

    }

    //void OnMouseUp()
    //{
    //    transform.position = new Vector2(currentPosition.x, currentPosition.y);
    //}
}
