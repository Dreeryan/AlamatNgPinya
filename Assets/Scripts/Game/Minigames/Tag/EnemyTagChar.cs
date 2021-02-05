using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTagChar : TagCharacter
{
    [SerializeField] private float      curSpeed = 3;

    [SerializeField] private Collider2D MoveArea;
    //[SerializeField] private Transform[] patrolPoints;

    private Vector2 destination;
    private SpriteFlipper sFlipper;

    protected override void Start()
    {
        base.Start();

        sFlipper = GetComponent<SpriteFlipper>();
    }

    void Update()
    {
        if (!isMinigameCompleted) AIRandom();
    }

    public void AIRandom()
    {
        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {
            destination = GetRandomPosition();
            if (sFlipper != null) sFlipper.FlipSprite(destination.x - transform.position.x);
        }

        transform.position = Vector2.MoveTowards(transform.position, destination, curSpeed * Time.deltaTime);
    }

    Vector2 GetRandomPosition() 
    {
        return new Vector2(
            Random.Range(MoveArea.bounds.min.x, MoveArea.bounds.max.x),
            Random.Range(MoveArea.bounds.min.y, MoveArea.bounds.max.y));
    }

    //protected override void OnCollisionEnter2D(Collision2D collision)
    //{
    //    base.OnCollisionEnter2D(collision);
    //    if (collision.collider.GetComponent<TagCharacter>())
    //    {
    //        destination = GetRandomPosition();
    //    }
    //}

}
