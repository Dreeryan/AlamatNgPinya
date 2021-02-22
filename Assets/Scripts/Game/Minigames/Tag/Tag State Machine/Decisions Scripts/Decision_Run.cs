using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Run")]
public class Decision_Run : Decision
{

    private bool hasStartedTimer = false;
    private float lastTimerTime;
    public float maxRunCooldown;
    public override bool Decide(StateController controller)
    {
       bool isTrasitioningToRun = TimeCooldown(controller);
       return isTrasitioningToRun;
    }

    private bool TimeCooldown(StateController controller)
    {
        Debug.Log(controller.timerManagerObj.CurTime);
        if (!hasStartedTimer)
        {
            // start Timer
          hasStartedTimer = true;
          this.lastTimerTime = controller.timerManagerObj.CurTime;
        }

        if (!hasStartedTimer) return false;
        // if time's up
        if ((controller.timerManagerObj.CurTime - this.lastTimerTime)>=maxRunCooldown)
        {

            // end and reset timer
            hasStartedTimer = !hasStartedTimer;
            this.lastTimerTime = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    

 
}
