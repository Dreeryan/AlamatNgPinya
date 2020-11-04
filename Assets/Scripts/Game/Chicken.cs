using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Transform    endPoint;
    public float        speed;

    private float       pushStrength;
    private bool        hasMoved;
    private Vector3     target;

    [SerializeField] private GameObject endPointObject;

    void Start()
    {
        target = transform.position;
        hasMoved = false;
        if (endPointObject != null)
            endPointObject.SetActive(false);
    }

    void Update()
    {
        OnMouseDown();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // Sets object the chickens will move to active
            if (endPointObject != null && !hasMoved)
                endPointObject.SetActive(true);

            // Gets the mouse cursor's position
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Keeps the Z-Position at 0
            target.z = transform.position.z;

            // Brings the endpoint to the position of where the click was made
            if (endPoint != null)
                endPoint.transform.position = target;
        }

        if (hasMoved == false)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Disables chicken movement once it moves to specified location
        if (transform.position == endPoint.position)
        {
            hasMoved = true;
            endPointObject.SetActive(false);
        }
    }
}