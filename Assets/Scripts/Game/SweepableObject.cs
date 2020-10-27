using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private GameObject broom;
    [SerializeField] float              pushStrength;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Place all objectives that happen once trash is sweeped to specified area here
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Sweeped to the right spot");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.position.Normalize();
        broom.transform.position.Normalize();

        // Pushes the object
        if (broom != null)
            GetComponent<Rigidbody2D>().AddForce((transform.position - broom.transform.position) * pushStrength);
    }
}
