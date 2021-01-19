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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "VisionChecker")
        {
            isSeen = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "VisionChecker")
        {
            isSeen = false;
        }
    }
}
