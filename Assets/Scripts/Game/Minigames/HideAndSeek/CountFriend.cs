using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFriend : MonoBehaviour
{
    [SerializeField] private FriendFound    friendFound;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D     collider;

    private void Start()
    {
        friendFound = FindObjectOfType<FriendFound>();
    }

    public void CountFriends()
    {
        // Counts a friend if found by player
        if (friendFound != null)
            friendFound.friendsFound++;

        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (collider != null)
            collider.enabled = false;
    }
}
