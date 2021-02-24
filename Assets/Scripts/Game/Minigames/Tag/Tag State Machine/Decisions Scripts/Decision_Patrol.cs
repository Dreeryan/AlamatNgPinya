using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Patrol")]
public class Decision_Patrol : Decision
{
    [SerializeField]private float distanceFromTarget;
    public override bool Decide(StateController controller)
    {
     //   if (GameManager.Instance.IsPaused) return false;
        bool isTrasitioningToRun = isFarFromTarget(controller);
        return isTrasitioningToRun;
    }

    private bool isFarFromTarget(StateController controller)
    {
        // if you're far from target go patrol
        if (Vector3.Distance(controller.transform.position,
                controller.targetToRunFrom.position) >= distanceFromTarget)
        {
            controller.rb2DComponent.velocity = new Vector2(0,0);
            return true;
        }
        else return false;
    }


}
