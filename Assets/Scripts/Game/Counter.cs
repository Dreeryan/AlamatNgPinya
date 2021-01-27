using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Counter : MonoBehaviour
{
    public  TextMeshProUGUI     counterText;
    public  int                 objectsCollected;
    private int                 previousObjectsCollected;
    private bool                isCounted;

    [SerializeField] private CollisionChecker   collisionChecker;
    [SerializeField] private int                objectGoal;
    [SerializeField] private GameObject         winScreen;
    [SerializeField] private string             objectTag;

    // Start is called before the first frame update
    void Start()
    {
        previousObjectsCollected = objectsCollected;

        // Sets the goal to how many items are active
        CheckForObjectsToCollect();

        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void CheckForObjectsToCollect()
    {
        objectGoal = GameObject.FindGameObjectsWithTag(objectTag).Length;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objectTag)
        {
            collisionChecker = collision.gameObject.GetComponent<CollisionChecker>();
        }
    }
}