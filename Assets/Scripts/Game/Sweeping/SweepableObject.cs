﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private GameObject     broom;
    [SerializeField] private float          pushStrength;
    [SerializeField] private Transform      itemHolder;
    [SerializeField] private TrashCounter   trashCounter;

    public ReturnIfVisionLost vision;

    private bool isPlaced;
    private Vector2 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }

    public void Update()
    {
        transform.position.Normalize();
        
        if (broom != null)
            broom.transform.position.Normalize();

        if (isPlaced == true)
            //A: Directly assign instead of making new vector if possible. This can cause memory issues
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);

        // Checks if trash can be seen by the camera
        if (vision.isSeen == false && vision != null)  
        {
            transform.position = currentPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Place all objectives that happen once trash is sweeped to specified area here
        if (collision.gameObject.tag == "Goal")
        {
            // Snaps the object into the specified area if it collides with it
            //A: Directly assign instead of making new vector if possible. This can cause memory issues
            transform.position = new Vector2(itemHolder.transform.position.x, itemHolder.transform.position.y);
            isPlaced = true;

            if (trashCounter != null)
            {
                // Adds a point to the trashCollected counter
                trashCounter.trashCollected++;
            }
        }
    }
}
