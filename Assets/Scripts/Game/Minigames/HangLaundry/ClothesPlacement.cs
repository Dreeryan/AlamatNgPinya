using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPlacement : MonoBehaviour
{
    [SerializeField] private float  valueToTarget = 1.2f;

    public Transform                itemHolder;
    public ClothingPositioning      clothingPosition;

    private Vector2                 mousePos;
    private Vector2                 currentPosition;
    private bool                    isOnGoal;
    private Counter                 counter;

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

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        if (counter != null && isOnGoal)
            counter.objectsCollected++;

        if (clothingPosition != null && isOnGoal)
        {
            transform.position = clothingPosition.GetNextAvailablePosition();
            clothingPosition.UpdateIndex();
            collider.enabled = false;
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
        if (collision.CompareTag("Goal"))
        {
            counter = collision.gameObject.GetComponent<Counter>();
            if (counter != null) isOnGoal = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal")) isOnGoal = false;
    }
}
