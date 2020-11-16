using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnIfVisionLost : MonoBehaviour
{
    // Detects manually if object is seen by the camera

    public bool isSeen;
    private Renderer renderers;

    void Start()
    {
        renderers = GetComponent<Renderer>();

    }

    void Update()
    {
        if (renderers.isVisible)
        {
            isSeen = true;
        }

        else
        {
            isSeen = false;
        }
    }
}
