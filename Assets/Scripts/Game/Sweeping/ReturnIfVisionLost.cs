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
        Vector3 maxScreen = new Vector3(Screen.width, Screen.height);
        Vector3 maxWorld = Camera.main.ScreenToWorldPoint(maxScreen);

        
    }
}
