using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private float          pushStrength;
    [SerializeField] private Transform      itemHolder;

    public ReturnIfVisionLost vision;

    private Vector2 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }

    public void Update()
    {
        transform.position.Normalize();
        
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
        if (collision.GetComponent<TrashBin>())
        {
            collision.GetComponent<TrashBin>().ThrowTrash(gameObject);
        }
    }
}
