using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnIfVisionLost : MonoBehaviour
{
    // Detects manually if object is seen by the camera

    public  bool     isSeen;
    private Renderer renderers;

    void Start()
    {
        isSeen = true;
        renderers = GetComponent<Renderer>();
    }

    private void Update()
    {
        CheckIfSeen();

        if (isSeen)
        {
            transform.position = transform.position;
        }
    }

    public void CheckIfSeen()
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
