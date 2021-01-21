using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private Transform eggBasket;

    private Vector2             mousePos;
    private Vector2             currentPosition;
    private bool                isOnGoal;

    public  bool                isPlaced;
    public  ReturnIfVisionLost  vision;

    [SerializeField] private CollisionChecker collisionChecker;
    [SerializeField] private Counter          counter;
    [SerializeField] private Collider2D       collider;
    void Start()
    {
        currentPosition = transform.position;
		//A: Finding via name is very risky and bug prone
        eggBasket = GameObject.Find("Egg Basket").transform;
    }

    private void Update()
    {
        if (vision.isSeen == false && vision != null)
            transform.position = currentPosition;
    }

    void OnMouseDrag()
    {
        // If the item is not yet placed while dragging, the item will be placed in the last position.
        if (!isPlaced)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    void OnMouseUp()
    {
        // If the object is near the item holder, the object will automatically be placed.
        if (Mathf.Abs(transform.position.x - eggBasket.transform.position.x) <= 1.2f &&
            Mathf.Abs(transform.position.y - eggBasket.transform.position.y) <= 1.2f)
        {
            transform.position = eggBasket.transform.position;
            isPlaced = true;
        }


        if (collisionChecker.hasCollided)
            transform.position = eggBasket.transform.position;

        if (isOnGoal)
            counter.objectsCollected++;

        // Else, it will be placed back to it's last position
        else
        {
            transform.position = currentPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            counter = collision.gameObject.GetComponent<Counter>();
            collider.enabled = false;

            // Adds a point for every item that collides with the goal
            if (counter != null)
                isOnGoal = true;

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        counter = collision.gameObject.GetComponent<Counter>();
        if (collision.gameObject.tag == "Goal")
        {
            isOnGoal = false;
        }
    }
}
