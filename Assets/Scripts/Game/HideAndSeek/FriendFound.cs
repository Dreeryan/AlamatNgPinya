using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFound : MonoBehaviour
{
    public  int friendsFound;
    private int previousFriendsFound;

    [SerializeField] private int        friendsGoal;
    [SerializeField] private GameObject winScreen;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    void Update()
    {
        // Detects number of friends present and sets it as the goal
        friendsGoal = GameObject.FindGameObjectsWithTag("Friend").Length;

        
		//A: Do this only after friendsFound was found.
        if (friendsFound > previousFriendsFound)
        {
            previousFriendsFound = friendsFound;

            // Opens win screen if all friends have been found
            if (friendsFound >= friendsGoal)
            {
                winScreen.SetActive(true);
            }
        }

    }
}
