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

    [SerializeField] private UnityEvent onFolded;

    private UnityEvent onCompleteFold = new UnityEvent();
    public  UnityEvent OnCompleteFold => onCompleteFold;

    [Header("Laundry Sprites")]
    [SerializeField] private Sprite[]   laundrySprites;
    [SerializeField] private GameObject     arrowSprite;

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
        arrowSprite.transform.localEulerAngles = new Vector3(0, 0, 90);
    }

    void Update()
    {
        if (!canBeFolded || GameManager.Instance.IsPaused) return;

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
            currentDirection = SwipeDirection();
            TwoFoldSequence();
        }
    }
    private Directions SwipeDirection()
    {
        float horizontalSwipe = Mathf.Abs(startPosition.x - endPosition.x);
        float verticalSwipe = Mathf.Abs(startPosition.y - endPosition.y);

        if (horizontalSwipe > 0 || verticalSwipe > 0)
        {
            if (horizontalSwipe > verticalSwipe)
            {
                if (startPosition.x > endPosition.x)    return Directions.Left;
                else                                    return Directions.Right;
            }
            else if (verticalSwipe > horizontalSwipe)
            {
                if (startPosition.y > endPosition.y)    return Directions.Down;
                else                                    return Directions.Up;
            }
        }
        return Directions.None;

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
        if (currentSequence > 2 || currentDirection == Directions.None) return;
        // Swipe from right to left
        if (currentSequence == 0 && currentDirection == Directions.Left)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[0];
            arrowSprite.transform.localEulerAngles = new Vector3(0, 0, 0);
            onFolded?.Invoke();
            currentSequence++;
        }

        // Swipe from top to bottom
        if (currentSequence == 1 && currentDirection == Directions.Up)
        {
            GetComponent<SpriteRenderer>().sprite = laundrySprites[1];
            arrowSprite.transform.localEulerAngles = new Vector3(0, 0, 90);
            onFolded?.Invoke();
            currentSequence++;
        }

        if (currentSequence == 2)
        {
            StartCoroutine(OnCompletelyFolded());
            arrowSprite.SetActive(false);
            currentSequence++;
        }

    }

    IEnumerator OnCompletelyFolded()
    {
        yield return new WaitForSeconds(1f);
        DisableCLothing();
        onCompleteFold.Invoke();

        //yield return null;
        //gameObject.SetActive(false);
    }

    public void EnableClothing()
    {
        canBeFolded = true;
        if (sRenderer != null) sRenderer.enabled = true;
        arrowSprite.gameObject.SetActive(true);

    }

    public void DisableCLothing()
    {
        canBeFolded = false;
        if (sRenderer != null) sRenderer.enabled = false;
    }
}
