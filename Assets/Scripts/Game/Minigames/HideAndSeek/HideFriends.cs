using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HideFriends : MonoBehaviour
{
    [SerializeField] private UnityEvent onFriendClicked;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D     collider;

    private void Start()
    {
        if (spriteRenderer == null) 
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (collider == null)
            collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPaused) return;
        CountFriends();
    }

    public void CountFriends()
    {
        // Counts a friend if found by player
        WinCheck.Instance.IncreaseProgress();

        onFriendClicked?.Invoke();

        gameObject.SetActive(false);
    }
}
