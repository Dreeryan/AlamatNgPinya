using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bucket : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    [Tooltip("Rotation of the sprite when the mouse pointer is above a plant")]
    private float canFillRotation = 30f;

    [SerializeField]
    [Tooltip("Rotation of the sprite when the mouse is clicked on top of a plant")]
    private float isFillingRotation = 60f;

    private bool canFill;
    private bool isFilling;

    [Header("Sound")]
    [SerializeField]
    private UnityEvent onFilling;

    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            isFilling = true;
            onFilling?.Invoke();
            UpdateSprite();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFilling = false;
            UpdateSprite();
        }
    }

    public void SetCanFill(bool p_canFill)
    {
        canFill = p_canFill;

        UpdateSprite();
    }

    public bool GetisFilling()
    {
        return isFilling;
    }

    void UpdateSprite()
    {
        if (canFill)
        {
            transform.rotation = Quaternion.Euler(0, 0, canFillRotation);

            if (isFilling)
                transform.rotation = Quaternion.Euler(0, 0, isFillingRotation);
        }
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
