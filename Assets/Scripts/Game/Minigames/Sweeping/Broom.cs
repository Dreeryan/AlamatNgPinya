using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Broom : MonoBehaviour
{
    [SerializeField] private Draggable draggable;

    private bool isSweeping;
    private bool isPickedUp;
    private bool isPlayingAudio;

    private List<GameObject> sweepedObjects = new List<GameObject>();

    [SerializeField] private UnityEvent onPickup;
    [SerializeField] private UnityEvent onSweeping;
    [SerializeField] private UnityEvent onStopSweeping;

    private void Start()
    {
        if (draggable == null) draggable = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSweeping && isPickedUp)
        {
            if (!isPlayingAudio)
            {
                isPlayingAudio = true;
                onSweeping?.Invoke();
            }
        }
        else
        {
            if (isPlayingAudio)
            {
                isPlayingAudio = false;
                onStopSweeping?.Invoke();
            }
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPaused) return;
        isPickedUp = true;
        onPickup?.Invoke();
    }

    private void OnMouseUp()
    {
        isPickedUp = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!sweepedObjects.Exists(obj => obj == collision.collider.gameObject))
        {
            sweepedObjects.Add(collision.collider.gameObject);
            isSweeping = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        sweepedObjects.RemoveAll(obj => obj == collision.collider.gameObject);
        if (sweepedObjects.Count == 0) isSweeping = false;
    }
}
