using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private GameObject broom;
    [SerializeField] private float      pushStrength;

    public void Update()
    {
        transform.position.Normalize();
        
        if (broom != null)
            broom.transform.position.Normalize();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Place all objectives that happen once trash is sweeped to specified area here
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Sweeped to the right spot");
        }
    }
}
