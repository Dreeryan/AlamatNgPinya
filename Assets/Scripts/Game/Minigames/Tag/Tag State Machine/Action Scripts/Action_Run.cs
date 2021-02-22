using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RunFromIt")]
public class Action_Run : Action
{
    [SerializeField] private float distance;
    [SerializeField] private float velocity;

    private void RunAwayFromTarget(StateController controller)
    {
        //Get the opposite direction of the target
        Vector3 TargetToRunTo = controller.transform.position - controller.targetToRunFrom.position;
        TargetToRunTo = TargetToRunTo.normalized;


        controller.rb2DComponent.AddForce(TargetToRunTo * velocity * Time.fixedDeltaTime);
    }

    private void TransitionToPatrol(StateController controller)
    {
        Debug.Log(Vector3.Distance(controller.transform.position, controller.targetToRunFrom.position));
        //WIP
        if (Vector3.Distance(controller.transform.position, controller.targetToRunFrom.position) >= distance)
        {
            velocity = 0;
            controller.rb2DComponent.velocity = new Vector2(0, 0);
            return;
        }
        else
        {
            velocity = 15;
        }

    }

    public override void Act(StateController controller)
    {
        RunAwayFromTarget(controller);
    }
}
