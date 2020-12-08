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

    [Header("Target and Patrol Points")]
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private Transform[] patrolPoints;

    [Header("Enemy Variables")]
    [SerializeField] private float curSpeed;
    [SerializeField] private float targetRange;

    private bool isIt = true;
    private Vector2 targetPos;
    private int randPoint;

    // Start is called before the first frame update
    void Start()
    {
        curState = EnemyState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case EnemyState.Chase: AIChase(); break;
            case EnemyState.Patrol: AIPatrol(); break;
        }

        if (isIt)
        {
            // curState = EnemyState.Chase;
        }
    }

    public void AIChase()
    {
        if (Vector2.Distance(targetPlayer.position, transform.position) > targetRange)
        {
            curState = EnemyState.Patrol;
            isIt = false;
        }

        transform.position = (Vector2.MoveTowards(transform.position, targetPlayer.position, curSpeed * Time.deltaTime));
    }

    public void AIPatrol()
    {
        if (Vector2.Distance(transform.position, patrolPoints[randPoint].position) < 0.1f)
        {
            randPoint = Random.Range(0, patrolPoints.Length);
        }

        if (Vector2.Distance(targetPlayer.position, transform.position) <= 2f)
        {
            curState = EnemyState.Chase;
        }

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randPoint].position, curSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targetPlayer = collision.gameObject.transform;
        }
    }
}
