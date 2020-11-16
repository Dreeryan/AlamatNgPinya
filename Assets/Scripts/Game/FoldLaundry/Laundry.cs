using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : MonoBehaviour
{
    public enum Directions
    {
        None = 0,
        Left = 1,
        Right = 2,
        Bottom = 3,
        Top = 4,
    }

    public Directions currentDirection;

    [SerializeField] private Sprite[] laundrySprites;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private bool isLeft;
    private bool isBottom;
    private bool isRight;
    private bool isTop;
    
    private int currentSequence;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = 0;
        currentSequence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;

        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            SwipeDirection();
            FoldSequence();
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
                if (startPosition.x > endPosition.x)
                {
                    currentDirection = Directions.Left;
                    print("Right to left swipe");
                    isLeft = true;
                    isRight = false;
                    isTop = false;
                    isBottom = false;
                }

                else
                {
                    currentDirection = Directions.Right;
                    print("Left to right swipe");
                    isRight = true;
                    isLeft = false;
                    isTop = false;
                    isBottom = false;
                }
            }

            else
            {
                if (startPosition.y > endPosition.y)
                {
                    currentDirection = Directions.Bottom;
                    print("Top to bottom swipe");
                    isBottom = true;
                    isTop = false;
                    isLeft = false;
                    isRight = false;
                }
                else
                {
                    currentDirection = Directions.Top;
                    print("Bottom to top swipe");
                    isTop = true;
                    isBottom = false;
                    isLeft = false;
                    isRight = false;
                }
            }
        }
    }

    public void FoldSequence()
    {
        // Swipe from left to right
        if (currentSequence == 0 && isLeft == false && isRight == true)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[0];
            currentSequence++;
        }

        // Swipe from right to left
        if (currentSequence == 1 && isLeft == true && isRight == false)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[1];
            currentSequence++;
        }

        // Swipe from bottom to top
        if (currentSequence == 2 && isTop == true && isBottom == false)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[2];
            currentSequence++;
        }
    }
}
