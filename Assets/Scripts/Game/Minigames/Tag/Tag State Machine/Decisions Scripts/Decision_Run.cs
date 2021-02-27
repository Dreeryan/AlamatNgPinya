using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Run")]
public class Decision_Run : Decision
{
   
    [SerializeField]private float stateChangeCooldown;
    [SerializeField]private float distanceToRun;

    public override bool Decide(StateController controller)
    {
       bool isTrasitioningToRun = TimeCooldown(controller);
       return isTrasitioningToRun;
    }

    private bool TimeCooldown(StateController controller)
    {
      //  if (GameManager.Instance.IsPaused) return false;
        controller.runDecisionTimer.AddTime();
        if (controller.runDecisionTimer.HasExceededTime(stateChangeCooldown))
        {
           
            if (Vector3.Distance(controller.transform.position,
                controller.targetToRunFrom.position) <= distanceToRun)
            {
                //near
                controller.runDecisionTimer.ResetTimer();
                return true;
            }
          
            else
            {
                //far
                return false;
            }
        }
        else return false;

    }
}
