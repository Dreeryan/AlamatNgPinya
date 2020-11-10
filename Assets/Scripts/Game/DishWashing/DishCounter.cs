using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishCounter : MonoBehaviour
{
    public int  dishCollected;
    private int previousDishCollected;

    [SerializeField] private int toysGoal;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        previousDishCollected = dishCollected;

        // Sets the goal to how many eggs are active
        toysGoal = GameObject.FindGameObjectsWithTag("Dish").Length;

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dishCollected > previousDishCollected)
        {
            previousDishCollected = dishCollected;

            if (dishCollected >= toysGoal)
            {
                winScreen.SetActive(true);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dish")
        {
            // Adds a point for every egg that collides with the egg basket
            dishCollected++;
        }
    }
}
