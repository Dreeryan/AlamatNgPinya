using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTagAI : MonoBehaviour
{
    private Transform chaseTarget;
    private Vector2 destination;
    private float targetRange;

    [SerializeField] private Collider2D MoveArea;
    //[SerializeField] private Transform[] patrolPoints;

    [Header("Enemy Variables")]
    [SerializeField] private float curSpeed;

    void Start()
    {
    }

    void Update()
    {
        AIRandom();
    }

    public void AIRandom()
    {
        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {
            destination = GetRandomPosition();
        }

        transform.position = Vector2.MoveTowards(transform.position, destination, curSpeed * Time.deltaTime);
    }

    Vector2 GetRandomPosition() 
    {
        return new Vector2(
            Random.Range(MoveArea.bounds.min.x, MoveArea.bounds.max.x),
            Random.Range(MoveArea.bounds.min.y, MoveArea.bounds.max.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TagCharacter collided = collision.collider.GetComponent<TagCharacter>();
        //if (collided != null) destination = GetRandomPosition();
    }
}
