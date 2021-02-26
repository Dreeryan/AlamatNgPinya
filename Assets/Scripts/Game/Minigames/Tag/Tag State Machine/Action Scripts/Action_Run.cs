﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RunFromIt")]
public class Action_Run : Action
{
    [SerializeField] private float runningSpeed;
    [SerializeField] private float switchNodeCooldown;
    Vector3 targetDirection;
    public override void Act(StateController controller)
    {
        base.Act(controller);
        RunAwayFromTarget(controller);
    }
    private void RunAwayFromTarget(StateController controller)
    {
        controller.objectTimer.AddTime();
        if (controller.objectTimer.HasExceededTime(switchNodeCooldown))
        {
            controller.rb2DComponent.velocity = new Vector2(0, 0);
            controller.objectTimer.ResetTimer();
            //Get the furthest node from the target
            this.SetFurthestNode(controller);
            // Vector3 targetDirection = controller.transform.position - controller.targetToRunFrom.position;
            targetDirection = (controller.currentTargetNode.position - controller.transform.position).normalized;
            targetDirection = targetDirection.normalized;
        }
        else controller.rb2DComponent.MovePosition(controller.transform.position + targetDirection * runningSpeed * Time.fixedDeltaTime);
        
    }



    private void SetFurthestNode(StateController controller)
    {
        for (int i = 0; i < controller.patrolNodes.Length; i++)
        {

            if (i == 0) controller.currentTargetNode = controller.patrolNodes[i];
            else
            {
                float currentNodeDistance = Vector3.Distance(controller.targetToRunFrom.position, controller.currentTargetNode.position);
                float nextNodedistance = Vector3.Distance(controller.targetToRunFrom.position, controller.patrolNodes[i].position);
                if (nextNodedistance > currentNodeDistance)
                {
                    controller.nodeCache.Add(controller.patrolNodes[i]);
                }
            }
        }
        //get top 3 nodes
        controller.currentTargetNode = controller.nodeCache[Random.Range(controller.nodeCache.Count - 3,
                                                                                controller.nodeCache.Count)];
       controller.nodeCache.Clear();
    }
}
