using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class Action_Chase : Action
{
    public LayerMask tagCharacterLayerMask;
    public float timeToSwitchTargets;
    public float chaseSpeed;
    private Transform targetToTag;


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

    private Transform GetNearbyNonTagged(StateController controller)
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(controller.transform.position, 3.5f, new Vector2(0, 0), 0, tagCharacterLayerMask);
        // List<Transform> nearbyNodes = new List<Transform>();
        if (hit == null) return null;
        if (hit.Length == 0) return null;

        if (hit.Length <= 2)
        {
            return hit[0].transform;
        }
        else
        {
            return hit[Random.Range(0, hit.Length - 1)].transform;
        }
    }
}
