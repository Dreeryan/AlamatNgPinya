using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Patrol")]
public class Decision_Patrol : Decision
{
    private bool hasStartedTimer = false;
    private float lastTimerTime;
    [SerializeField]private float distanceFromTarget;
    public override bool Decide(StateController controller)
    {
        bool isTrasitioningToRun = isFarFromTarget(controller);
        return isTrasitioningToRun;
    }

    private bool isFarFromTarget(StateController controller)
    {
        // if you're far from target go patrol
        if (Vector3.Distance(controller.transform.position,
                controller.targetToRunFrom.position) >= distanceFromTarget) return true;
        else return false;
    }


}
