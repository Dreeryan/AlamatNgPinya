using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFriend : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D     collider;

    private Counter counter;
    private void Start()
    {
        if (spriteRenderer == null) 
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (collider == null)
            collider = GetComponent<Collider2D>();

        counter = FindObjectOfType<Counter>();
        if (counter != null)
            counter.IncreaseGoalCount(1);
    }

    private void OnMouseDown()
    {
        CountFriends();
    }

    public void CountFriends()
    {
        // Counts a friend if found by player

        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (collider != null)
            collider.enabled = false;

        if (counter != null)
            counter.IncreaseProgress();
    }
}
