using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onFeedPickedUp;
    [SerializeField] private UnityEvent onShakeAudio;
    [SerializeField] private UnityEvent onShake;
    [SerializeField] private UnityEvent onStopShake;

    [SerializeField] private Draggable draggable;

    private bool            isOnFeedArea;
    private bool            isShaking;
    private bool            isAudioPlaying;
    private SpriteRenderer  sRenderer;

    public bool IsOnFeedArea => isOnFeedArea;
    public bool IsShaking => isShaking;

    private void Start()
    {
        isOnFeedArea    = false;
        isShaking       = false;

        sRenderer = GetComponent<SpriteRenderer>();

        if (draggable == null) 
            draggable = GetComponent<Draggable>();
    }

    private void OnMouseDrag()
    {
        if (draggable == null) return;

        if (draggable.HasMovedEnough)
            isShaking = true;
        else
            isShaking = false;

        if (isShaking && isOnFeedArea)
        {
            if (!isAudioPlaying)
            {
                onShakeAudio?.Invoke();
                isAudioPlaying = true;
            }
            onShake?.Invoke();

            if (sRenderer != null)
                sRenderer.flipY = true;
        }
        else
        {
            if (isAudioPlaying)
            {
                onStopShake?.Invoke();
                isAudioPlaying = false;
            }
        }
    }

    void OnMouseDown()
    {
        onFeedPickedUp?.Invoke();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If animal feed is on a shakeable area
        if (collision.GetComponent<FeedHolder>())
        {
            isOnFeedArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If animal feed leaves the shakeable area
        if (collision.GetComponent<FeedHolder>())
        {
            isOnFeedArea = false;
            if (sRenderer != null)
                sRenderer.flipY = false;
        }
    }
}