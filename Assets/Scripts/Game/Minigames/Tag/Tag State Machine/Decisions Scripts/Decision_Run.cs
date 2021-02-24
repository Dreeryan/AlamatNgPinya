using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Run")]
public class Decision_Run : Decision
{
    
    private float elapsedTime;
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
        AddTime();
        if (HasExceededTime(stateChangeCooldown))
        {
           
            if (Vector3.Distance(controller.transform.position,
                controller.targetToRunFrom.position) <= distanceToRun)
            {
                //near
                ResetTimer();
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


    public bool HasExceededTime(float TimeToWait)
    {
        if (elapsedTime >= TimeToWait)
        {
            return true;
        }
        else return false;
    }

    public void AddTime()
    {
        elapsedTime += Time.deltaTime;
    }


    public void ResetTimer()
    {
        elapsedTime = 0;
    }



}
