using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    [SerializeField] private int                spawnCount = 3; 
    [SerializeField] private PositionRandomizer positionRandomizer;
    [SerializeField] private List<GameObject>   friendPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject>   spawnedItems  = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Sets hiding spots as spawn points
            Vector3 hidingSpot = positionRandomizer.GetSpawnPosition();

            Random hidingSpotRandomizer = new Random();

            GameObject newFriends = Instantiate(friendPrefabs[i], spawnedItems[i].transform.position, Quaternion.identity);

        }
    }

    public Vector3 GetSpawnPosition()
    {
        // Selects a position from the gameObjects in the list and warps the friend to it's location
        int index = Random.Range(0, positionRandomizer.friendPositions.Length);

        return positionRandomizer.friendPositions[index].transform.position;
    }


}
