using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private UnityEvent OnPlayerMove;
    [SerializeField] private UnityEvent OnPlayerStop;
    [SerializeField] private float limitOffset;
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
        if (!CanMove || GameManager.Instance.IsPaused) return;
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            SetMovePosition();

            if (sFlipper != null)
                sFlipper.FlipSprite(targetPoint.x - transform.position.x);

            if (!isMoving)
            {
                OnPlayerMove?.Invoke();

                if (playerAnim != null) playerAnim.PlayerWalking(true);

                isMoving = true;
            }
        }

        if (isMoving) Movement();       
    }

    private void SetMovePosition()
    {
        // Player will go to the clicked area.
        targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPoint.z = transform.position.z;
    }

    void Movement()
    {
        // To move the player to the desired position
        if (IsOnEdgeOfScreen(targetPoint))
        {
            OnPlayerStop?.Invoke();
            if (playerAnim != null) playerAnim.PlayerWalking(false);
            isMoving = false;
            return;
        }
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

    bool IsOnEdgeOfScreen(Vector3 targetPosition)
    {
        targetPosition = Camera.main.WorldToViewportPoint(targetPosition);
        Debug.Log(targetPosition);
        if (targetPosition.x < 0.0 + limitOffset) return true;
        if (1.0 - limitOffset < targetPosition.x) return true;
        if (targetPosition.y < 0.0 + limitOffset) return true;
        if (1.0 - limitOffset < targetPosition.y) return true;

        Debug.Log("pwede magmove");
        return false;

    }
}
