using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    public bool hasCollided;

    [SerializeField] private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
    }

    public void Update()
    {
        if (hasCollided)
        {
            if (col != null)
                col.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
		//A: Make this a variable so its very flexible
        if (collision.gameObject.tag == "Goal")
        {
            hasCollided = true;
        }
    }
}
