using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 targetPoint;
    private Vector3 defaultAngle = new Vector3(0, 0, 0);
    private Vector3 newAngle = new Vector3(0, 180, 0);

    public bool isMoving;

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

        SetTargetPoint();

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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isMoving = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isMoving = false;
    }

    void SetTargetPoint()
    {
        if (targetPoint.x < -1)
        {
            transform.localEulerAngles = defaultAngle;
        }

        // // If the mouse position is greater than -1, the player's y rotation axis will be flipped to 0
        else
        {
            transform.localEulerAngles = newAngle;
        }
    }
}
