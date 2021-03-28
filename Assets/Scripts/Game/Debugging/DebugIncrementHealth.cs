using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugIncrementHealth : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey = KeyCode.F3;
    // Update is called once per frame
    void Update()
    {
        if (PineappleLifeManager.Instance == null) return;
        if (Input.GetKeyDown(resetKey))
        { 
            ResetHealth(); 
        }
    }

    private void ResetHealth()
    {
        PineappleLifeManager.Instance.ResetAmount();
    }
}
