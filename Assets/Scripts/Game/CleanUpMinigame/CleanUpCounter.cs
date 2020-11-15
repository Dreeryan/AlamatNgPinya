using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//A: You might want to make this a general class that can handle all instances of this mechanic. Just expose more variables like tag to make it flexible
public class CleanUpCounter : MonoBehaviour
{
    public int  toysCollected;
    private int previousToysCollected;

    [SerializeField] private int        toysGoal;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        previousToysCollected = toysCollected;

        // Sets the goal to how many toys are active
        toysGoal = GameObject.FindGameObjectsWithTag("Item").Length;

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (toysCollected > previousToysCollected)
        {
            previousToysCollected = toysCollected;

            if (toysCollected >= toysGoal)
            {
                winScreen.SetActive(true);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            // Adds a point for every toys that collides with the collector
            toysCollected++;
        }
    }
}
