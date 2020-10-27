using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float speed = 5;

    [SerializeField] private Vector3 targetPoint;
    public bool isMoving;

    // Update is called once per frame
    void Update()
    {
        // Left click to move
        if (Input.GetMouseButton(0))
        {
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint.z = transform.position.z;
            isMoving = true;
        }

        if (isMoving)
        {
            Movement();
        }
    }

    void Movement()
    {
        // Player will go to the desired position
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPoint);
		
        if (transform.position == targetPoint)
        {
            isMoving = false;
        }
    }
}
