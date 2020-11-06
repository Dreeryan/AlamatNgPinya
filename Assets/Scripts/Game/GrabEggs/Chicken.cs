using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Transform    endPoint;
    public float        speed;
    private Vector3     target;

    [SerializeField] private GameObject endPointObject;
    [SerializeField] private bool       isSelected;
    void Start()
    {
        target = transform.position;
        isSelected = false;
    }

    private void Update()
    {
        if (isSelected)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSelected = true;
            // Gets the mouse cursor's position
            target = endPointObject.transform.position;

            // Keeps the Z-Position at 0
            target.z = transform.position.z;
        }

        // Disables chicken movement once it moves to specified location
        if (transform.position == endPoint.position)
        {
            if (endPointObject != null)
                endPointObject.SetActive(false);
        }
    }
}