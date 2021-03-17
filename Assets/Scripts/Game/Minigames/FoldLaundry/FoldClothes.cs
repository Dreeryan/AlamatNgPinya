using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Directions
{
    None = 0,
    Left = 1,
    Right = 2,
    Down = 3,
    Up = 4,
}
public class FoldClothes : MonoBehaviour
{
    public UnityEvent OnCompletelyFold = new UnityEvent { };

    [SerializeField] private ClothesDatabase clothesDB;
    [SerializeField] public Transform arrowSprite;
    [SerializeField] private string clothId;
    [SerializeField] private int currentNumberOfTimesFolded = 0;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField]private bool canBeFolded = false;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private Directions currentDirection;

    private void Start()
    {
        SetArrowRotation();
    }
    private void Update()
    {
        if (!canBeFolded) return;
        SetDirection();
    }

    private Directions SwipeDirection()
    {
        float horizontalSwipe = Mathf.Abs(startPosition.x - endPosition.x);
        float verticalSwipe = Mathf.Abs(startPosition.y - endPosition.y);

        if (horizontalSwipe > 0 || verticalSwipe > 0)
        {
            if (horizontalSwipe > verticalSwipe)
            {
                if (startPosition.x > endPosition.x) return Directions.Left;
                else return Directions.Right;
            }
            else if (verticalSwipe > horizontalSwipe)
            {
                if (startPosition.y > endPosition.y) return Directions.Down;
                else return Directions.Up;
            }
        }
        return Directions.None;
    }

    private void SetDirection()
    {
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
            CheckForFoldSequence();
            SetArrowRotation();
        }
    }

    private void CheckForFoldSequence()
    {
        if (!canBeFolded) return;
        if (currentNumberOfTimesFolded >= clothesDB.GetData(this.clothId).
            clothesFoldingDirection.Length) return;

        if (currentDirection == clothesDB.GetData(this.clothId).
            clothesFoldingDirection[currentNumberOfTimesFolded])
        {
            sRenderer.sprite = clothesDB.GetData(this.clothId).foldedClothesSprite[currentNumberOfTimesFolded];
            currentNumberOfTimesFolded += 1;
        }

        if (currentNumberOfTimesFolded >= clothesDB.GetData(this.clothId).
            clothesFoldingDirection.Length)
        {
            Debug.Log("Done folding");
            StartCoroutine(OnCompletelyFolded());
            return;
        }
    }

    IEnumerator OnCompletelyFolded()
    {
        yield return new WaitForSeconds(1f);
        DisableCLothing();
        OnCompletelyFold.Invoke();
    }

    public void DisableCLothing()
    {
        canBeFolded = false;
        if (sRenderer != null) sRenderer.enabled = false;
        arrowSprite.gameObject.SetActive(false);
    }

    public void EnableClothing()
    {
        canBeFolded = true;
        if (sRenderer != null) sRenderer.enabled = true;
        arrowSprite.gameObject.SetActive(true);

    }

    private void SetArrowRotation()
    {
        // Only set arrow rotation to the amount of times folded
        if (this.currentNumberOfTimesFolded >= clothesDB.GetData(this.clothId).
            clothesFoldingDirection.Length) return;

        if (clothesDB.GetData(this.clothId).
            clothesFoldingDirection[currentNumberOfTimesFolded]== Directions.Up) 
            arrowSprite.localEulerAngles = new Vector3(0, 0, 0);
        if (clothesDB.GetData(this.clothId).
            clothesFoldingDirection[currentNumberOfTimesFolded] == Directions.Right) 
            arrowSprite.localEulerAngles = new Vector3(0, 0, 270);
        if (clothesDB.GetData(this.clothId).
            clothesFoldingDirection[currentNumberOfTimesFolded] == Directions.Down) 
            arrowSprite.localEulerAngles = new Vector3(0, 0, 180);
        if (clothesDB.GetData(this.clothId).
            clothesFoldingDirection[currentNumberOfTimesFolded] == Directions.Left) 
            arrowSprite.localEulerAngles = new Vector3(0, 0, 90);
    }

}
