using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class LaundryCounter : MonoBehaviour
{
    public  int clothesCollected;
    private int previousClothesCollected;

    [SerializeField] private GameObject             winScreen;
    [SerializeField] private int                    laundryGoal;
    [SerializeField] private UnityEvent             OnHanging;
    

    // Start is called before the first frame update
    void Start()
    {
        clothesCollected = 0;
        previousClothesCollected = clothesCollected;

        // Sets the goal to how many clothes are active
        laundryGoal = GameObject.FindGameObjectsWithTag("Clothing").Length;

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (clothesCollected > previousClothesCollected)
        {
            previousClothesCollected = clothesCollected;

            if (clothesCollected >= laundryGoal)
            {

                winScreen.SetActive(true);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothing")
        {
            // Adds a point for every egg that collides with the clothesline
            clothesCollected++;
            OnHanging.Invoke();
        }
    }
}
