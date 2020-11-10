using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaundryCounter : MonoBehaviour
{
    public int clothesCollected;
    private int previousClothesCollected;

    [SerializeField] private int laundryGoal;

    // Start is called before the first frame update
    void Start()
    {
        previousClothesCollected = clothesCollected;

        // Sets the goal to how many eggs are active
        laundryGoal = GameObject.FindGameObjectsWithTag("Clothing").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (clothesCollected > previousClothesCollected)
        {
            previousClothesCollected = clothesCollected;

            if (clothesCollected >= laundryGoal)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothing")
        {
            // Adds a point for every egg that collides with the egg basket
            clothesCollected++;
        }
    }
}
