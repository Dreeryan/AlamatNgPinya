using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chicken : MonoBehaviour
{
    [SerializeField] private UnityEvent onChickenClicked;

    public Transform    endPoint;
    public float        speed;
    public float        moveOffset = 0.01f;

    private bool        isSelected;
    private Vector3     endPos;

    void Start()
    {
        endPos = transform.position;
        isSelected = false;
    }

    private void Update()
    {
        if (isSelected)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, endPos) <= moveOffset) isSelected = false;
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;

        if (endPoint != null)
            endPos = endPoint.position;

        // Keeps the Z-Position at 0
        endPos.z = transform.position.z;

        GetComponent<SpriteFlipper>().FlipSprite(transform.position.x - endPos.x);
        GetComponent<Collider2D>().enabled = false;

        onChickenClicked?.Invoke();
    }
}