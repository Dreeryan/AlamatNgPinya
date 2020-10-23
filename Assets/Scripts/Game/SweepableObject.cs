using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepableObject : MonoBehaviour
{
    [SerializeField] private GameObject broom;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Sweeped to the right spot");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Broom")
        //{
        //    var magnitude = 10000;

        //    var force = transform.position - GameObject.FindWithTag("Broom").transform.position;

        //    force.Normalize();
        //    GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var magnitude = 500; // Strength of the push

        var force = transform.position - broom.transform.position;

        force.Normalize();
        GetComponent<Rigidbody2D>().AddForce(force * magnitude);
    }
}
