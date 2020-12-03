using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    public GameObject[] friendPositions;

    // Start is called before the first frame update
    void Start()
    {
        // Selects a position from the gameObjects in the list and warps the friend to it's location
        int index = Random.Range(0, friendPositions.Length);
        transform.position = friendPositions[index].transform.position;
    }

}
