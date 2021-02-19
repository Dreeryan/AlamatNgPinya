using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothesToHang : MonoBehaviour
{
    [SerializeField] private UnityEvent onClothingPickedUp;

    [SerializeField] private float      valueToTarget = 1.2f;

    private Vector2                 mousePos;
    private Vector2                 currentPosition;
    private bool                    isOnGoal;
    private ClothesLine             clothesLine;

    [SerializeField] private bool               canSnapbackToStart;
    [SerializeField] private ReturnIfVisionLost vision;
    [SerializeField] private Collider2D         collider;

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

    public void EnableClothing()
    {
        collider.enabled = true;
    }

    public void DisableClothing()
    {
        collider.enabled = false;
    }

    private void OnMouseDown()
    {
        onClothingPickedUp?.Invoke();
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        if (clothesLine != null && isOnGoal)
        {
            clothesLine.HangClothing(this);
            //EnableClothing();
        }
        // Else, it will be placed back to it's last position
        else
        {
            // Snapback can be turned on or off in the Inspector
            if (canSnapbackToStart)
                transform.position = currentPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ClothesLine>())
        {
            clothesLine = collision.GetComponent<ClothesLine>();
            if (clothesLine != null) isOnGoal = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ClothesLine>() == clothesLine)
        {
            clothesLine = null;
            isOnGoal = false;
        }
    }
}
