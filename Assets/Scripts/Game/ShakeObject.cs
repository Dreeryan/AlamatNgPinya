using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public UnityEvent OnShake;
    public Transform shakeObject;

    private bool     isOnFeedArea;
    private bool    isMouseDrag;
    private Vector2 currentPosition;
    private Vector2 mousePos;
    private Vector2 previousPos = Vector2.zero;
    private float   threshold   = 0.1f;

    // This is for testing
    [SerializeField] private bool isShaking;

    private void Start()
    {
        isOnFeedArea = false;
        isShaking = false;
    }

    void Update()
    {
        // Triggers shaking
        if (isMouseDrag && isOnFeedArea)
            isShaking = true;

        else
            isShaking = false;

        if (isShaking)
            OnShake.Invoke();
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        isMouseDrag = true;
    }

    void OnMouseUp()
    {
        // The object will snap back to it's original position
        transform.position = currentPosition;

        isMouseDrag = false;
    }

    void OnMouseDown()
    {
        previousPos = Input.mousePosition;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If animal feed is on a shakeable area
        if (collision.gameObject.CompareTag("FeedArea"))
        {
            isOnFeedArea = true;
            Debug.Log("Is On Feed Area");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If animal feed leaves the shakeable area
        if (collision.gameObject.CompareTag("FeedArea"))
        {
            isOnFeedArea = false;
            Debug.Log("Left Feed Area");
        }
    }

    public void Test()
    {
        Debug.Log("Shook");
    }
}