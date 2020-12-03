using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFound : MonoBehaviour
{
    public int friendsFound;
    private int previousFriendsFound;

    [SerializeField] private int friendsGoal;
    [SerializeField] private GameObject winScreen;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    void Update()
    {
        friendsGoal = GameObject.FindGameObjectsWithTag("Friend").Length;

        if (friendsFound > previousFriendsFound)
        {
            previousFriendsFound = friendsFound;

            if (friendsFound >= friendsGoal)
            {
                winScreen.SetActive(true);
            }
        }

    }
}
