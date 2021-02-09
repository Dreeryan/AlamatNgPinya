using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFeedPickedUp;

    [SerializeField] private UnityEvent OnShake;

    private bool            isOnFeedArea;
    private bool            isMouseDrag;
    private bool            isShaking;
    private Vector2         currentPosition;
    private Vector2         mousePos;
    private SpriteRenderer  sRenderer;

    private void Start()
    {
        isMouseDrag     = false;
        isOnFeedArea    = false;
        isShaking       = false;

        sRenderer = GetComponent<SpriteRenderer>();

        currentPosition = gameObject.transform.position;

    }

    void Update()
    {
        if (transform.hasChanged)
        {
            isMouseDrag = true;
            transform.hasChanged = false;
        }

        else
        {
            isMouseDrag = false;
        }

        if (!isMouseDrag)
        {
            isShaking = false;  
        }

        // Calls event is object is shaken
        if (isShaking)
            OnShake?.Invoke();
    }

    void OnMouseDown()
    {
        OnFeedPickedUp?.Invoke();
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        // The object will snap back to it's original position
        transform.position = currentPosition;

        isMouseDrag = false;
        isShaking = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If animal feed is on a shakeable area
        if (collision.gameObject.CompareTag("FeedArea"))
        {
            isOnFeedArea = true;

            // Triggers shaking
            if (isOnFeedArea && isMouseDrag)
            {
                isShaking = true;

                if (sRenderer != null)
                    sRenderer.flipY = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If animal feed leaves the shakeable area
        if (collision.gameObject.CompareTag("FeedArea"))
        {
            isOnFeedArea = false;
            isShaking = false;
            sRenderer.flipY = false;
        }
    }
}