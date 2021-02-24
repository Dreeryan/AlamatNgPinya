using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class Action_Patrol : Action
{
    [SerializeField] private float patrolSpeed;

    private bool hasStartedTimer = false;
    private float lastTimerTime;
    [SerializeField] private float timeToSwitch;
    private Vector3 randomDirection;
    // Start is called before the first frame update
    void Start()
    {
        hasStartedTimer = false;
       // randomAdditiveVector = new Vector3(Random.Range(-distanceToPatrol, distanceToPatrol), Random.Range(-distanceToPatrol, distanceToPatrol));
    }


    // Update is called once per frame
    private void RandomPatrol(StateController controller)
    {
        controller.objectTimer.AddTime();
        if (controller.objectTimer.HasExceededTime(timeToSwitch))
        {
            controller.objectTimer.ResetTimer();
            randomDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
            randomDirection = (randomDirection - controller.transform.position).normalized;
            controller.rb2DComponent.velocity = new Vector3(0, 0);
        }
        else controller.rb2DComponent.MovePosition(controller.transform.position + randomDirection * patrolSpeed * Time.fixedDeltaTime);


    }

    public override void Act(StateController controller)
    {
        RandomPatrol(controller);
    }
}
