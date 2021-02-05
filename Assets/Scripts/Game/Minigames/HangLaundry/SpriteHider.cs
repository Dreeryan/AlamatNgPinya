using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHider : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;
    }

    // Shows sprite when collider is clicked
    private void OnMouseDown()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;
    }
}
