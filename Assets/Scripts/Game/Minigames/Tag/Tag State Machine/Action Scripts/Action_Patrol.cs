using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class Action_Patrol : Action
{
    [SerializeField] private float distanceToPatrol;
    [SerializeField] private float velocity;
    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        randomPosition += new Vector3(Random.Range(-distanceToPatrol, distanceToPatrol), Random.Range(-distanceToPatrol, distanceToPatrol));
    }


    // Update is called once per frame
    private void RandomPatrol(StateController controller)
    {

        if (Vector3.Distance(controller.transform.position, randomPosition) >= 2)
        {

            //   rbComponent.MovePosition()
            //    rbComponent.AddForce(randomPosition.normalized * velocity * Time.fixedDeltaTime);

            // go to location
            // dont change location
            return;
        }
        else
        {
            controller.rb2DComponent.velocity = new Vector2(0, 0);
            randomPosition += new Vector3(Random.Range(-distanceToPatrol, distanceToPatrol), Random.Range(-distanceToPatrol, distanceToPatrol));
        }
    }

    public override void Act(StateController controller)
    {
        RandomPatrol(controller);
    }
}
