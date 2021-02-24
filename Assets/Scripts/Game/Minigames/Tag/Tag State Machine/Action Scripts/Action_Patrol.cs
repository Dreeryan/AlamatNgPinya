using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class Action_Patrol : Action
{
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float timeToSwitch;

    private Vector3 randomDirection;
    // Update is called once per frame
    private void RandomPatrol(StateController controller)
    {
        controller.objectTimer.AddTime();
        if (controller.objectTimer.HasExceededTime(timeToSwitch))
        {
            controller.objectTimer.ResetTimer();
            // change this later
            randomDirection = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2));
            randomDirection = (randomDirection - controller.transform.position).normalized;
            controller.rb2DComponent.velocity = new Vector3(0, 0);
        }
        else controller.rb2DComponent.MovePosition(controller.transform.position + randomDirection * patrolSpeed * Time.fixedDeltaTime);
    }

    public override void Act(StateController controller)
    {
        base.Act(controller);
        RandomPatrol(controller);
    }
}
