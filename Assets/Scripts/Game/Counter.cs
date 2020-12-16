using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    public  TextMeshProUGUI counterText;
    public  int             objectsCollected;
    private int             previousObjectsCollected;

    [SerializeField] private int        objectGoal;
    [SerializeField] GameObject winScreen;
    [SerializeField] private UnityEvent onPlacement;
    [SerializeField] CleanToy cleanToy;
    // Start is called before the first frame update
    void Start()
    {
        previousObjectsCollected = objectsCollected;

        // Sets the goal to how many items are active
        objectGoal = GameObject.FindGameObjectsWithTag("Item").Length;

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        objectGoal = GameObject.FindGameObjectsWithTag("Item").Length;
        if (objectsCollected > previousObjectsCollected)
        {
            previousObjectsCollected = objectsCollected;

            if (objectsCollected >= objectGoal)
            {
                winScreen.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

        counterText.text = "Collected: " + objectsCollected + " / " + objectGoal;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            cleanToy = collision.gameObject.GetComponent<CleanToy>();
            // Adds a point for every item that collides with the goal
            objectsCollected++;
            cleanToy.gameObject.GetComponent<Collider2D>().enabled = false;
            onPlacement.Invoke();
        }
    }
}