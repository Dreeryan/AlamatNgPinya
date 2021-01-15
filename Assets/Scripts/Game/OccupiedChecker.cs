using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedChecker : MonoBehaviour
{
    [SerializeField] private FriendSpawner friendSpawner;

    public bool isOccupied; 

    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOccupied)
            friendSpawner.GetSpawnPosition();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Friend")
        {
            isOccupied = true;
        }
    }
}
