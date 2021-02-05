using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private GameObject     broom;
    [SerializeField] private float          pushStrength;
    [SerializeField] private Transform      itemHolder;
    [SerializeField] private Counter        counter;

    public ReturnIfVisionLost vision;

    private bool    isPlaced;
    private Vector2 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;

        if (counter == null) counter = FindObjectOfType<Counter>();
        if (counter != null) counter.IncreaseGoalCount(1);
    }

    public void Update()
    {
        transform.position.Normalize();
        
        if (broom != null)
            broom.transform.position.Normalize();

        if (isPlaced == true)
            //A: Directly assign instead of making new vector if possible. This can cause memory issues
            transform.position = itemHolder.transform.position;

        // Checks if trash can be seen by the camera
        if (vision.isSeen == false && vision != null)  
        {
            transform.position = currentPosition;
        }

        Vector3 trashPos = transform.position;

        trashPos.y = Mathf.Clamp(trashPos.y, -4.2f, 1.85f);
        trashPos.x = Mathf.Clamp(trashPos.x, -9.5f, 6.3f);
        transform.position = trashPos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Place all objectives that happen once trash is sweeped to specified area here
        if (collision.CompareTag("Goal"))
        {
            // Snaps the object into the specified area if it collides with it
            //A: Directly assign instead of making new vector if possible. This can cause memory issues
            transform.position = itemHolder.transform.position;
            isPlaced = true;

            if (counter != null) counter.IncreaseProgress();
        }
    }
}
