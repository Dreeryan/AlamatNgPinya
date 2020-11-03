﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeObject : MonoBehaviour
{
    public UnityEvent OnShake;
    private Vector2 startPos;
    private Vector3 randomPos;
    private bool goingUp;

    // This is for testing
    [SerializeField] private bool isShaking;
    void Update()
    {
       if (isShaking)
        {
            OnShake.Invoke();
        }

       // Hold Space to shake
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShaking = true;
        }

        // Release Space to stop shaking
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShaking = false;
        }

    }

    public void Shaking()
    {
        if (goingUp)
        {
            transform.Translate(0, 0.1f, 0);
            goingUp = false;
        }

        else
        {
            transform.Translate(0, -0.1f, 0);
            goingUp = true;
        }
    }

}
