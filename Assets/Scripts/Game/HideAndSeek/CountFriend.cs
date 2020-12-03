using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFriend : MonoBehaviour
{
    [SerializeField] private FriendFound friendFound;

    public void CountFriends()
    {
        friendFound.friendsFound++;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
