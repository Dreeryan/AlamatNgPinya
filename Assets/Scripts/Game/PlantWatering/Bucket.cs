using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    [Tooltip("Rotation of the sprite when the mouse pointer is above a plant")]
    private float canFillRotation;

    [SerializeField]
    [Tooltip("Rotation of the sprite when the mouse is clicked on top of a plant")]
    private float isFillingRotation;

    private bool canFill;
    private bool isFilling;

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetCanFill(bool p_canFill)
    {
        canFill = p_canFill;

        UpdateSprite();
    }

    public void SetIsFilling(bool p_isFilling)
    {
        isFilling = p_isFilling;

        UpdateSprite();
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
