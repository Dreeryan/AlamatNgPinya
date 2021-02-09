using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerMove;
    [SerializeField] private UnityEvent OnPlayerStop;

    [Header("Player move speed")]
    [SerializeField] private float moveSpeed;
    [Tooltip("Distance the player can be from the target position before stopping")]
    [SerializeField] private float moveOffset = 0.01f;

    public bool                 CanMove =   true;

    private SpriteFlipper       sFlipper;
    private PlayerAnimations    playerAnim;
    private Vector3             targetPoint;
    private bool                isMoving =  false;

    public PlayerAnimations     PlayerAnim => playerAnim;

    protected void Start()
    {
        CanMove = true;
        playerAnim = GetComponent<PlayerAnimations>();
        sFlipper = GetComponent<SpriteFlipper>();
    }

    void Update()
    {
        if (!CanMove || Time.timeScale == 0) return;
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            SetMovePosition();

            if (sFlipper != null) 
                sFlipper.FlipSprite(targetPoint.x - transform.position.x);

            OnPlayerMove?.Invoke();
            
            if (playerAnim != null) playerAnim.PlayerWalking(true);

            isMoving = true;
        }

        if (isMoving) Movement();       
    }

    private void SetMovePosition()
    {
        // Player will go to the clicked area.
        targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPoint.z = transform.position.z;
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }

    void Movement()
    {
        // To move the player to the desired position
        transform.position = Vector3.MoveTowards(transform.position,
            targetPoint, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) <= moveOffset)
        {
            OnPlayerStop?.Invoke();          
            if (playerAnim != null) playerAnim.PlayerWalking(false);

            isMoving = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (isMoving)
        {
            OnPlayerStop?.Invoke();
            if (playerAnim != null) playerAnim.PlayerWalking(false);
            isMoving = false;
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isMoving = false;
    //}
}
