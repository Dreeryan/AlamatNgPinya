using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothesToFold : MonoBehaviour
{
    private enum Directions
    {
        None = 0,
        Left = 1,
        Right = 2,
        Down = 3,
        Up = 4,
    }
    private Directions currentDirection;

    private UnityEvent onClothingFolded = new UnityEvent();
    public  UnityEvent OnClothingFolded => onClothingFolded;

    [Header("Laundry Sprites")]
    [SerializeField] private Sprite[]   laundrySprites;

    private int            currentSequence;
    private bool           canBeFolded = false;
    private Vector2        startPosition;
    private Vector2        endPosition;
    private SpriteRenderer sRenderer;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        
        currentDirection = 0;
        currentSequence = 0;

        Counter counter = FindObjectOfType<Counter>();
        if (counter != null) counter.IncreaseGoalCount(1);
    }

    void Update()
    {
        if (!canBeFolded || Time.timeScale == 0.0f) return;

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            endPosition = startPosition;
        }

        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            SwipeDirection();
            TwoFoldSequence();
        }
    }
    public void SwipeDirection()
    {
        float horizontalSwipe = Mathf.Abs(startPosition.x - endPosition.x);
        float verticalSwipe = Mathf.Abs(startPosition.y - endPosition.y);

        if (horizontalSwipe > 0 || verticalSwipe > 0)
        {
            if (horizontalSwipe > verticalSwipe)
            {
                if (startPosition.x > endPosition.x)    currentDirection = Directions.Left;
                else                                    currentDirection = Directions.Right;
            }
            else if (verticalSwipe > horizontalSwipe)
            {
                if (startPosition.y > endPosition.y)    currentDirection = Directions.Down;
                else                                    currentDirection = Directions.Up;
            }
            else return;
        }
    }

    public void FoldSequence()
    {
		//A: Just use the enums instead of setting and checking 4 booleans
		
        // Swipe from left to right
        //if (currentSequence == 0 && currentDirection == Directions.Right)
        //{
        //    GetComponent<SpriteRenderer>().sprite = laundrySprites[0];
        //    currentSequence++;
        //}

        //// Swipe from right to left
        //if (currentSequence == 1 && currentDirection == Directions.Left)
        //{
        //    GetComponent<SpriteRenderer>().sprite = laundrySprites[1];
        //    currentSequence++;
        //}

        //// Swipe from bottom to top
        //if (currentSequence == 2 && currentDirection == Directions.Top)
        //{
        //    GetComponent<SpriteRenderer>().sprite = laundrySprites[2];
        //    currentSequence++;
        //}
    }

    public void TwoFoldSequence()
    {
        // Swipe from right to left
        if (currentSequence == 0 && currentDirection == Directions.Left)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[0];
            currentSequence++;
        }

        // Swipe from top to bottom
        if (currentSequence == 1 && currentDirection == Directions.Up)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[1];
            currentSequence++;
        }

        if (currentSequence == 2)
        {
            StartCoroutine(OnFolded());
            currentSequence++;
        }
    }

    IEnumerator OnFolded()
    {
        yield return new WaitForSeconds(1f);
        DisableCLothing();
        onClothingFolded.Invoke();

        //yield return null;
        //gameObject.SetActive(false);
    }

    public void EnableClothing()
    {
        canBeFolded = true;
        if (sRenderer != null) sRenderer.enabled = true;
    }

    public void DisableCLothing()
    {
        canBeFolded = false;
        if (sRenderer != null) sRenderer.enabled = false;
    }
}
