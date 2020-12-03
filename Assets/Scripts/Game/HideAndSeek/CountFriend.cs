using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFriend : MonoBehaviour
{
    [SerializeField] private FriendFound friendFound;

    public void CountFriends()
    {
        // Counts a friend if found by player
        friendFound.friendsFound++;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
