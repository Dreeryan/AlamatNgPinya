using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Transform endPoint;
    public float speed;

    private float pushStrength;
    private Vector3 target;

    [SerializeField] private bool isSelected;
    [SerializeField] private GameObject endPointObject;

    void Start()
    {
        target = transform.position;
        isSelected = false;
        endPointObject.SetActive(false);
    }

    void Update()
    {
        OnMouseDown();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && isSelected == true)
        {
            // Sets object the chickens will move to active
            if (endPointObject != null)
                endPointObject.SetActive(true);

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

    private void OnMouseOver()
    {
        // For selection of chickens that will move
        //Left Click to deselect
        if (Input.GetMouseButtonDown(0))
        {
            isSelected = true;
        }

        // Right Click to deselect
        if (Input.GetMouseButtonDown(1))
        {
            isSelected = false;
            endPointObject.SetActive(false);
        }
    }
}