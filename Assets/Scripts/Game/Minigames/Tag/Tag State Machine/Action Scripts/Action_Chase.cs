using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class Action_Chase : Action
{
    public float timeToSwitchTargets;
    public float chaseSpeed;
    private Transform targetToTag;

    
    public override void Act(StateController controller)
    {
        base.Act(controller);

        if (!controller.hasChosenTarget)
        {
            ChaseTarget(controller);
          
        }
        else if (controller.hasChosenTarget)
        {
            controller.chaseActionTimer.AddTime();
            if (controller.chaseActionTimer.HasExceededTime(timeToSwitchTargets))
            {
                controller.chaseActionTimer.ResetTimer();
                controller.hasChosenTarget = false;
                ChooseFromNonTagged(controller);
            }
        }
    }

    private void ChooseFromNonTagged(StateController controller)
    {
        int randomNumber;
        if (controller.tagManagerObj.GetNonTagged().Count <= 1)
        {
            randomNumber = 0;
            targetToTag = controller.tagManagerObj.GetPlayerCharacter().transform;
        }
        else if (controller.tagManagerObj.GetNonTagged().Count>1)
        {
            randomNumber = Random.Range(0, (controller.tagManagerObj.GetNonTagged().Count - 1));
            targetToTag = controller.tagManagerObj.GetNonTagged()[randomNumber].transform;
        }

    }

    private void ChaseTarget(StateController controller)
    {
        controller.movementDirection = (targetToTag.position - controller.transform.position).normalized;   
        controller.rb2DComponent.MovePosition(controller.transform.position + controller.movementDirection * chaseSpeed * Time.fixedDeltaTime);
    }

}
