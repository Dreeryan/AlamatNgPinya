using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Broom : MonoBehaviour
{
    [SerializeField] private UnityEvent onSweeping;

    private bool isSweeping;
    private List<GameObject> sweepedObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (isSweeping && transform.hasChanged)
        {
            onSweeping?.Invoke();
            transform.hasChanged = false;
        }
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
