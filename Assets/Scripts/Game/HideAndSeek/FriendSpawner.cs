using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    private int spawnCount;

    [SerializeField] private PositionRandomizer positionRandomizer;
    [SerializeField] private List<GameObject>   friendPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject>   spawnedItems  = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject friend in friendPrefabs)
        {
            // Sets hiding spots as spawn points
            Vector3 hidingSpot = positionRandomizer.GetSpawnPosition();

            GameObject newFriends = Instantiate(friend, hidingSpot, Quaternion.identity);

            spawnedItems.Add(newFriends);
            spawnCount = spawnedItems.Count;
        }
    }

}
