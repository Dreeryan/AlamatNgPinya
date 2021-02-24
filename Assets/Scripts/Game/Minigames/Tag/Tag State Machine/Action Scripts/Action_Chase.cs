using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class Action_Chase : Action
{

    public float chaseSpeed;
    private float elapsedTime;
    private Transform targetToTag;

    [SerializeField] private float changeTargetCooldown;

    public override void Act(StateController controller)
    {
        base.Act(controller);
    }

    private void ChooseFromNonTagged(StateController controller)
    {
        int randomNumber = Random.Range(0, (controller.tagManagerObj.GetNonTagged().Count - 1));
        targetToTag = controller.tagManagerObj.GetNonTagged()[randomNumber].transform;
    }

    private void ChaseTarget(StateController controller)
    {
        Vector3 targetDirection = (targetToTag.position - controller.transform.position).normalized;
        controller.rb2DComponent.MovePosition(controller.transform.position + targetDirection * chaseSpeed * Time.fixedDeltaTime);
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
