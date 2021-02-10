using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Egg : MonoBehaviour
{
    [SerializeField] private UnityEvent onEggPickedUp;
    [SerializeField] private UnityEvent onEggDropped;

    [SerializeField] private Transform eggBasket;

    private Vector2             mousePos;
    private Vector2             currentPosition;
    private bool                isOnGoal;
    private bool                isPlaced;

    public  ReturnIfVisionLost  vision;

    [SerializeField] private CollisionChecker collisionChecker;
    [SerializeField] private Counter          counter;
    [SerializeField] private Collider2D       collider;
    void Start()
    {
        currentPosition = transform.position;

        if (eggBasket == null) eggBasket = FindObjectOfType<Counter>().transform;
        if (counter == null) counter = FindObjectOfType<Counter>();
        if (counter != null) counter.IncreaseGoalCount(1);
    }

    private void Update()
    {
        if (vision.isSeen == false && vision != null)
            transform.position = currentPosition;
    }

    private void OnMouseDown()
    {
        onEggPickedUp?.Invoke();
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
        if (isOnGoal)
        {
            // Adds a point for every item that collides with the goal
            if (counter != null) counter.IncreaseProgress();

            onEggDropped?.Invoke();
            transform.position = eggBasket.transform.position;
            if (collider != null) collider.enabled = false;
            isPlaced = true;
        }
        else
        {
            transform.position = currentPosition;
        }
    }

    private bool IsNearHolder()
    {
        return Mathf.Abs(transform.position.x - eggBasket.transform.position.x) <= 1.2f &&
               Mathf.Abs(transform.position.y - eggBasket.transform.position.y) <= 1.2f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            isOnGoal = true;

            if (counter == null)
                counter = collision.gameObject.GetComponent<Counter>();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        counter = null;
        if (collision.CompareTag("Goal"))
        {
            isOnGoal = false;
        }
    }
}
