using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool           spriteFacingRight;

    private Vector2 lastPosition;
    private Vector2 currentPosition;
    private bool    isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        isFlipped= false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFlipped)
        {
            if (spriteRenderer != null)
                spriteRenderer.flipX = true;
        }

        else
        {
            if (spriteRenderer != null)
                spriteRenderer.flipX = false;
        }

        if (spriteFacingRight)
            FlippedSprite();

        else
            NormalSprite();

    }

    // If the sprite asset is facing right initially
    void NormalSprite()
    {
        // If moving right
        if (transform.position.x > lastPosition.x)
        {
            isFlipped = true;
        }

        // If moving left  
        if (transform.position.x < lastPosition.x)
        {
            isFlipped = false;
        }

        lastPosition = transform.position;
    }

    // If the sprite asset is facing left initially
    void FlippedSprite()
    {
        // If moving left
        if (transform.position.x > lastPosition.x)
        {
            isFlipped = false;
        }

        // If moving right  
        if (transform.position.x < lastPosition.x)
        {
            isFlipped = true;
        }

        lastPosition = transform.position;
    }
}
