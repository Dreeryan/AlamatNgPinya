using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 targetPoint;
    private bool isMoving = false;
    private bool playerIsIt = true;

    public SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint.z = transform.position.z;
            isMoving = true;
        }

        if (isMoving)
        {
            Movement();
        }

        if (playerIsIt)
        {
            spriteRend.color = Color.blue;
        }
        else
        {
            spriteRend.color = Color.white;
        }
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if (transform.position == targetPoint)
        {
            isMoving = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !playerIsIt)
        {
            playerIsIt = true;
        }

        else
        {
            playerIsIt = false;
        }
    }
}
