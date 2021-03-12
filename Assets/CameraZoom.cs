using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public SpriteRenderer boundSprite;
    // Start is called before the first frame update
    void Start()
    {
        Zoom();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Zoom()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = boundSprite.bounds.size.x / boundSprite.bounds.size.y;

        if(screenRatio>= targetRatio)
        {
         //   Camera.main.orthographicSize = boundSprite.bounds.size.y / 2;
            Camera.main.orthographicSize = boundSprite.bounds.size.y / 2;
        }
        else
        {
            float sizeDifference = targetRatio / screenRatio;
            Camera.main.orthographicSize = boundSprite.bounds.size.y / 2 * sizeDifference;
        }
        //float orthoSize = boundSprite.bounds.size.x * Screen.height / Screen.width * 0.5f;

        //Camera.main.orthographicSize = orthoSize;
    }
}
