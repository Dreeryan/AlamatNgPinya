using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTag : MonoBehaviour
{
    public enum EnemyState
    {
        Run = 0,
        Chase = 1,
        Patrol = 2,
        Attack = 3,
    }

    public EnemyState curState;

    private bool enemyIsIt = false;
    private Vector2 targetPos;
    private int randPoint;
    private SpriteRenderer spriteRend;

    [Header("Target and Patrol Points")]
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private Transform[] patrolPoints;

    [Header("Enemy Variables")]
    [SerializeField] private float curSpeed;
    [SerializeField] private float targetRange;

    // Start is called before the first frame update
    void Start()
    {
        curState = EnemyState.Patrol;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case EnemyState.Chase: AIChase(); break;
            case EnemyState.Patrol: AIPatrol(); break;
        }

        if (enemyIsIt)
        {
            spriteRend.color = Color.black;
        }
        else
        {
            spriteRend.color = Color.white;
        }
    }

    public void AIChase()
    {
        if (Vector2.Distance(targetPlayer.position, transform.position) > targetRange)
        {
            curState = EnemyState.Patrol;
        }

        transform.position = (Vector2.MoveTowards(transform.position, targetPlayer.position, curSpeed * Time.deltaTime));
    }

    public void AIPatrol()
    {
        if (Vector2.Distance(transform.position, patrolPoints[randPoint].position) < 0.1f)
        {
            randPoint = Random.Range(0, patrolPoints.Length);
        }

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randPoint].position, curSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !enemyIsIt)
        {
            targetPlayer = collision.gameObject.transform;
            enemyIsIt = true;
        }

        else
        {
            enemyIsIt = false;
        }
    }
}
