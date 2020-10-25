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
        // Strength of the push
		//A: Im not a fan of implicitly setting variables when you already know this is a vector 3 from the start
		// This can cause confusion when an outsider comes in
        var force = transform.position - broom.transform.position;

        force.Normalize();
        // Pushes the object
		
		//A: Null check
        GetComponent<Rigidbody2D>().AddForce(force * pushStrength);
    }
}
