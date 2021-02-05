using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    private bool    isSpoonFull;
    public bool     IsSpoonFull => isSpoonFull;

    [Header("Spoon Sprites")]
    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Sprite emptySprite;


    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillSpoon()
    {
        isSpoonFull = true;
        if (sRenderer != null) sRenderer.sprite = fullSprite;
    }

    public void EmptySpoon()
    {
        isSpoonFull = false;
        if (sRenderer != null) sRenderer.sprite = emptySprite;
    }

}
