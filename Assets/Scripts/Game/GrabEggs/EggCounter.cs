using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class EggCounter : MonoBehaviour
{
    public  TextMeshProUGUI counterText;
    public  int             eggsCollected;
    private int             previousEggsCollected;

    [SerializeField] private int        eggGoal;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private UnityEvent onEggPlacement;
    // Start is called before the first frame update
    void Start()
    {
        previousEggsCollected = eggsCollected;

        // Sets the goal to how many eggs are active
        eggGoal = GameObject.FindGameObjectsWithTag("Egg").Length;

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (eggsCollected > previousEggsCollected)
        {
            previousEggsCollected = eggsCollected;

            if (eggsCollected >= eggGoal)
            {
                winScreen.SetActive(true);
            }
        }

        counterText.text = "Eggs collected: " + eggsCollected + " / " + eggGoal;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            // Adds a point for every egg that collides with the egg basket
            eggsCollected++;
            onEggPlacement.Invoke();
        }
    }
}