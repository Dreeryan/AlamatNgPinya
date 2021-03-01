using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class Action_Patrol : Action
{
    [SerializeField] private float distanceTravel;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float timeToSwitch;

    // Update is called once per frame
    private void RandomPatrol(StateController controller)
    {
        controller.patrolActionTimer.AddTime();
        if (controller.patrolActionTimer.HasExceededTime(timeToSwitch))
        {
            controller.patrolActionTimer.ResetTimer();
            // change this later
            // randomDirection = new Vector3(Random.Range((controller.transform.position.x- distanceTravel), controller.transform.position.x + distanceTravel), Random.Range(controller.transform.position.x - distanceTravel, controller.transform.position.x + distanceTravel));

            this.SetNearestNode(controller);
            controller.movementDirection = controller.currentTargetNode.position;
            controller.movementDirection = (controller.movementDirection - controller.transform.position).normalized;
            controller.rb2DComponent.velocity = new Vector3(0, 0);
        }
        else controller.rb2DComponent.MovePosition(controller.transform.position + controller.movementDirection * patrolSpeed * Time.fixedDeltaTime);
    }

    private void SetNearestNode(StateController controller)
    {
        controller.currentTargetNode = controller.GetRandomNearbyNode();

    }
    public override void Act(StateController controller)
    {
        base.Act(controller);
        RandomPatrol(controller);
    }

}
