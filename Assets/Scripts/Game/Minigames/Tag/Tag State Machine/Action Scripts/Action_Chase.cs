using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class Action_Chase : Action
{
    public float timeToSwitchTargets;
    public float chaseSpeed;
    private Transform targetToTag;

    [SerializeField] private float changeTargetCooldown;

    public override void Act(StateController controller)
    {
        base.Act(controller);

        controller.chaseActionTimer.AddTime();
        if (controller.chaseActionTimer.HasExceededTime(timeToSwitchTargets))
        {
            controller.chaseActionTimer.ResetTimer();
            ChooseFromNonTagged(controller);
      
        }
        ChaseTarget(controller);
    }

    private void ChooseFromNonTagged(StateController controller)
    {
        
        int randomNumber = Random.Range(0, (controller.tagManagerObj.GetNonTagged().Count - 1));
       // randomNumber = 0;
        targetToTag = controller.tagManagerObj.GetNonTagged()[randomNumber].transform;
    }

    private void ChaseTarget(StateController controller)
    {
        controller.movementDirection = (targetToTag.position - controller.transform.position).normalized;   
        controller.rb2DComponent.MovePosition(controller.transform.position + controller.movementDirection * chaseSpeed * Time.fixedDeltaTime);
    }
}
