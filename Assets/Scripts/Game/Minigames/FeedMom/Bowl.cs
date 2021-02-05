using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [Header("Bowl Settings")]
    [SerializeField] private int maxSoupCount = 5;
    public  int MaxSoupCount => maxSoupCount;
    private int curSoupCount;
    public  int CurSoupCount => curSoupCount;
    public bool IsEmpty => curSoupCount == 0;

    [Header("Sprites  (Change to animation later)")]
    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Sprite emptySprite;


    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        curSoupCount = maxSoupCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReduceSoupAmount()
    {
        curSoupCount--;
        if (curSoupCount < 0) curSoupCount = 0;

        if (IsEmpty && sRenderer != null) 
            sRenderer.sprite = emptySprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spoon>())
        {
            if (IsEmpty) return;
            Spoon spoon = collision.GetComponent<Spoon>();
            if (spoon.IsSpoonFull) return;
            spoon.FillSpoon();
            ReduceSoupAmount();
        }
    }
}
