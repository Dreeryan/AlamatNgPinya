using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggCounter : MonoBehaviour
{
    public int eggsCollected;
    private int previousEggsCollected;

    [SerializeField] private int eggGoal;

    // Start is called before the first frame update
    void Start()
    {
        previousEggsCollected = eggsCollected;

        // Sets the goal to how many eggs are active
        eggGoal = GameObject.FindGameObjectsWithTag("Egg").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (eggsCollected > previousEggsCollected)
        {
            previousEggsCollected = eggsCollected;

            if (eggsCollected >= eggGoal)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            // Adds a point for every egg that collides with the egg basket
            eggsCollected++;
        }
    }
}