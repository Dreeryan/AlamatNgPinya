using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    public bool hasCollided;

    [SerializeField] private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
    }

    public void Update()
    {
        if (hasCollided)
        {
            if (collider != null)
                collider.enabled = false;
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
