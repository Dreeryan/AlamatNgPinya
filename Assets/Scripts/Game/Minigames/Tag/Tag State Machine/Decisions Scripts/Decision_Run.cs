using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Run")]
public class Decision_Run : Decision
{
    
    private bool hasStartedTimer = false;
    private float lastTimerTime;
    [SerializeField]private float stateChangeCooldown;
    [SerializeField]private float distanceToRun;
    public override bool Decide(StateController controller)
    {
       bool isTrasitioningToRun = TimeCooldown(controller);
       return isTrasitioningToRun;
    }

    private bool TimeCooldown(StateController controller)
    {
        // if you're near target and cooldown is up go run
        Debug.Log(controller.timerManagerObj.CurTime);
        if (!hasStartedTimer)
        {
            // start Timer
          hasStartedTimer = true;
          this.lastTimerTime = controller.timerManagerObj.CurTime;
        }

        if (!hasStartedTimer) return false;
        // if time's up
        if ((controller.timerManagerObj.CurTime - this.lastTimerTime) >= stateChangeCooldown)
        {
            // end and reset timer
            hasStartedTimer = !hasStartedTimer;
            this.lastTimerTime = 0;
            if (Vector3.Distance(controller.transform.position,
                controller.targetToRunFrom.position) <= distanceToRun) return true;
            else return false;
        }
        else return false;
        
    }
    

 
}
