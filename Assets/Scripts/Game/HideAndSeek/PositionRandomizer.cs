using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    public Vector2[] friendPositions;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, friendPositions.Length);
        transform.position = friendPositions[randomNumber];
    }

}
