using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Transform endPoint;
    public float     speed;

    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        OnMouseDown();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Gets the mouse cursor's position
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Keeps the Z-Position at 0
            target.z = transform.position.z;

            // Brings the endpoint to the position of where the click was made
            if (endPoint != null)
                endPoint.transform.position = target;
        }

        // Tells the chicken to move to the endpoint's postion
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
