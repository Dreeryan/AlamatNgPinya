using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public  UnityEvent  OnShake;

    private Vector3     lastPosition;
    private Vector3     currentPosition;

    private float       velocity;

    // This is for testing
    [SerializeField] private bool isShaking;

    private void Awake()
    {
        lastPosition = transform.position;
    }

    private void Start()
    {
        lastPosition = transform.position;
        //Draggable d   ragObject = FindObjectOfType<Draggable>();
        //dragObject.OnMouseDrag();
    }

    void Update()
    {
        currentPosition = transform.position;

        if (isShaking)
        {
            OnShake.Invoke();
        }



        if (currentPosition.x < lastPosition.x)
        {
            isShaking = true;
        }


        else if (currentPosition.x > lastPosition.x)
        {
            isShaking = false;
        }


        lastPosition = currentPosition;
    }

    public void Test()
    {
        Debug.Log("Shook");
    }
}
