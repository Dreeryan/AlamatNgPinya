using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    public GameObject[] friendPositions;

    // Start is called before the first frame update
    public Vector3 GetSpawnPosition()
    {
        // Selects a position from the gameObjects in the list and warps the friend to it's location
        int index = Random.Range(0, friendPositions.Length);

        return friendPositions[index].transform.position;
    }

}
