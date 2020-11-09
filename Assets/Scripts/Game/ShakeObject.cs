using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public UnityEvent   OnShake;
    public Transform    shakeObject;

    private Vector3     lastPosition;
    private Vector3     currentPosition;
    private float       threshold = 0.0f;

    // This is for testing
    [SerializeField] private bool isShaking;


    private void Start()
    {
        lastPosition = shakeObject.position;
    }

    void Update()
    {
        currentPosition = shakeObject.position - lastPosition;

        lastPosition = shakeObject.position;
        // For shaking left and right
        if (currentPosition.x > threshold || currentPosition.x < -threshold)
        {
            // Updates last position
            lastPosition = shakeObject.position;

            isShaking = true;
        }

        // For shaking up and down
        if (currentPosition.y > threshold || currentPosition.y < -threshold)
        {
            // Updates last position
            lastPosition = shakeObject.position;

            isShaking = true;   
        }

        if (currentPosition == lastPosition)
        {
            // Updates last position
            lastPosition = shakeObject.position;
            isShaking = false;
        }

        if (isShaking)
        {
            OnShake.Invoke();
        }

        Debug.Log("cur: " + currentPosition);
        Debug.Log("last: " + lastPosition);
    }

    public void Test()
    {
        Debug.Log("Shook");
    }
}
