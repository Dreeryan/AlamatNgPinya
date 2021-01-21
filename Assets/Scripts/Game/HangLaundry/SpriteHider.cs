using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHider : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

//A: null check
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.enabled = false;
    }

    // Shows sprite when collider is clicked
    private void OnMouseDown()
    {
        spriteRenderer.enabled = true;
    }
}
