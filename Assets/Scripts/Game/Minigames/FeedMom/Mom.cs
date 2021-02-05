using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spoon>())
        {
            Spoon spoon = collision.GetComponent<Spoon>();
            if (spoon.IsSpoonFull) spoon.EmptySpoon();
        }
    }
}
