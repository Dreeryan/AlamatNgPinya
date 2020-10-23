using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector3 targetPoint;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {

    }

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

    // Player movement
    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPoint);
        if (transform.position == targetPoint)
        {
            isMoving = false;
        }
    }
}
