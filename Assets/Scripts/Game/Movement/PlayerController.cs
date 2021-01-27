using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player move speed")]
    [SerializeField] private float moveSpeed;
    [Tooltip("Distance the player can be from the target position before stopping")]
    [SerializeField] private float moveOffset = 0.01f;

    private Animator    playerAnim;
    private Vector3     targetPoint;
    private bool        isMoving = false;
    private bool        canMove  = true;
    public bool         CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }


    protected void Start()
    {
        canMove = true;
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!canMove) return;
        if (Input.GetMouseButtonUp(0))
        {
            // Player will go to the clicked area.
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint.z = transform.position.z;
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

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

        // Uneeded for now
        //if (Input.GetMouseButton(1))
        //{
        //    playerAnim.Play("Player_Pickup");
        //}
    }

    void Movement()
    {
        // To move the player to the desired position
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
       
        if (Vector3.Distance(transform.position, targetPoint) <= moveOffset)
        {
            isMoving = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isMoving = false;
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isMoving = false;
    //}
}
