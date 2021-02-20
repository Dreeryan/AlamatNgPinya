using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Patrol : MonoBehaviour
{
    [SerializeField] private float distanceToPatrol;
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody2D rbComponent;
    private Vector3 randomPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        randomPosition += new Vector3(Random.Range(-distanceToPatrol, distanceToPatrol), Random.Range(-distanceToPatrol, distanceToPatrol));
    }

    private void Update()
    {
        RandomPatrol();
    }
    // Update is called once per frame
    private void RandomPatrol()
    {

        if (Vector3.Distance(this.transform.position, randomPosition) >=2)
        {

         //   rbComponent.MovePosition()
        //    rbComponent.AddForce(randomPosition.normalized * velocity * Time.fixedDeltaTime);

            // go to location
            // dont change location
            return;
        }
        else
        {
            rbComponent.velocity = new Vector2(0, 0);
            randomPosition += new Vector3(Random.Range(-distanceToPatrol, distanceToPatrol), Random.Range(-distanceToPatrol, distanceToPatrol));
        }
    }
}
