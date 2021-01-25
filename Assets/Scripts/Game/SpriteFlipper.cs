using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            SetDestination();

            if (destination.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    void SetDestination()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
