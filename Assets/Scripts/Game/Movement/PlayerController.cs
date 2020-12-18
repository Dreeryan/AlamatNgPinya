using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player move speed")]
    [SerializeField] private float moveSpeed;

    public Animator playerAnim;

    private Vector3 targetPoint;
    private Vector3 defaultAngle = new Vector3(0, 0, 0);
    private Vector3 newAngle = new Vector3(0, 180, 0);

    public bool isFacingRight = false;
    [HideInInspector]
    public bool isMoving = false;
    [SerializeField] private SpriteRenderer spriteRenderer;


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Player will go to the clicked area.
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint.z = transform.position.z;
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPoint);

            Vector3 currentRotation = transform.localEulerAngles;
            currentRotation.z = 0;
            transform.localEulerAngles = currentRotation;

            isMoving = true;
        }

        // To move the player
        if (isMoving)
        {
            Movement();
            if (playerAnim != null) playerAnim.Play("Player_Running");
        }
        else
        {
            if (playerAnim != null) playerAnim.Play("Player_Idle");
        }
    }

    void Movement()
    {
        // To move the player to the desired position
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
       
        if (transform.position == targetPoint)
        {
            isMoving = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isMoving = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isMoving = false;
    }
}
