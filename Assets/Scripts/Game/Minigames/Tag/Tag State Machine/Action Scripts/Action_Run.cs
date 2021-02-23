using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RunFromIt")]
public class Action_Run : Action
{
    [SerializeField] private float runningSpeed;

    private void RunAwayFromTarget(StateController controller)
    {
        //Get the opposite direction of the target
        Vector3 targetDirection = controller.transform.position - controller.targetToRunFrom.position;
        targetDirection = targetDirection.normalized;


        controller.rb2DComponent.MovePosition(controller.transform.position + targetDirection * runningSpeed * Time.fixedDeltaTime);
    }

    public override void Act(StateController controller)
    {
        RunAwayFromTarget(controller);
    }
}
