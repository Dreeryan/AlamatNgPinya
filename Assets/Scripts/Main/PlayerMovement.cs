using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    Vector3 targetPoint;
    public float moveSpeed = 5f;
    public float slowDown = 0.5f;
    private bool isMoving;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Player will go to the clicked area.
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPoint);

            Vector3 currentRotation = transform.localEulerAngles;
            currentRotation.z = 0;
            transform.localEulerAngles = currentRotation;

            isMoving = true;
        }

        // If the mouse position is less than -1, the player's y rotation axis will be flipped to 180
        if (targetPoint.x < -1)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        // // If the mouse position is greater than -1, the player's y rotation axis will be flipped to 0
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        // To move the player
        if (isMoving)
        {
            Movement();
        }
    }

    void Movement()
    {
        // To move the player to the desired position
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if (transform.position == targetPoint)
        {
            isMoving = false;

        }
    }
}
