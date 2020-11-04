using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerResizer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        // Converts
        gameObject.transform.localScale = Camera.main.WorldToScreenPoint(gameObject.transform.localScale * 10);
        Debug.Log(gameObject.transform.localScale);
    }
}
