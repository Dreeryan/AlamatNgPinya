using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RunFromIt")]
public class Action_Run : Action
{
    [SerializeField] private Vector2 mapLimit;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float switchNodeCooldown;
    public override void Act(StateController controller)
    {
        base.Act(controller);
        RunAwayFromTarget(controller);
    }
    private void RunAwayFromTarget(StateController controller)
    {
        SetRandomNode(controller);

        if (controller.chaseActionTimer.HasExceededTime(switchNodeCooldown))
        {
            controller.rb2DComponent.velocity = new Vector2(0, 0);
            controller.chaseActionTimer.ResetTimer();
            //Get the furthest node from the target
            this.SetFurthestNode(controller);
            // Vector3 targetDirection = controller.transform.position - controller.targetToRunFrom.position;
            controller.movementDirection = (controller.transform.position - controller.targetToRunFrom.position).normalized;
            controller.movementDirection = controller.movementDirection.normalized;
        }
        else
        {
            controller.chaseActionTimer.AddTime();
            controller.rb2DComponent.MovePosition(controller.transform.position + controller.movementDirection * runningSpeed * Time.fixedDeltaTime);
        }
            
    }

    private void SetRandomNode(StateController controller)
    {
        //// Limit the map so the ai doesn't go outside of map
        ///
        //Choose a random node to run to when you're at the edge of the map

        if (controller.transform.position.x < mapLimit.x && controller.transform.position.x > -mapLimit.x   
            && controller.transform.position.y < mapLimit.y && controller.transform.position.y > -mapLimit.y) return;
        else 
        {
            int randomNumber = Random.Range(0, controller.patrolNodes.Length);
            controller.movementDirection = (controller.patrolNodes[randomNumber].position - controller.transform.position).normalized;
            controller.rb2DComponent.MovePosition(controller.transform.position + controller.movementDirection * runningSpeed * Time.fixedDeltaTime);
        }
    }

    private void SetFurthestNode(StateController controller)
    {
       // for (int i = 0; i < controller.patrolNodes.Length; i++)
       // {

       //     if (i == 0) controller.currentTargetNode = controller.patrolNodes[i];
       //     else
       //     {
       //         float currentNodeDistance = Vector3.Distance(controller.targetToRunFrom.position, controller.currentTargetNode.position);
       //         float nextNodedistance = Vector3.Distance(controller.targetToRunFrom.position, controller.patrolNodes[i].position);
       //         if (currentNodeDistance > nextNodedistance)
       //         {
       //             controller.nodeCache.Add(controller.patrolNodes[i]);
       //         }
       //     }
       // }
       // //get top 3 nodes
       // controller.currentTargetNode = controller.nodeCache[controller.nodeCache.Count-1];
       //controller.nodeCache.Clear();
    }
}
