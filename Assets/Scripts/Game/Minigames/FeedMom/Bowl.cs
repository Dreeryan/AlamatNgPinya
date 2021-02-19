using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bowl : MonoBehaviour
{
    [SerializeField] private UnityEvent OnScooped;

    [Header("Bowl Settings")]
    private float curSoupCount;
    public  float CurSoupCount => curSoupCount;
    public bool IsEmpty => curSoupCount == 0;

    [Header("Sprites  (Change to animation later)")]
    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Sprite emptySprite;

    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        curSoupCount = WinCheck.Instance.Goal;
    }

    void ReduceSoupAmount()
    {
        curSoupCount--;
        if (curSoupCount < 0) curSoupCount = 0;

        if (IsEmpty && sRenderer != null) 
            sRenderer.sprite = emptySprite;

        OnScooped?.Invoke();
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
