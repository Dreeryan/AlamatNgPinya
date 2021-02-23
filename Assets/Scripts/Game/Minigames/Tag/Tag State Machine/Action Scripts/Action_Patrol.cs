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
        //Vector3 targetPosition = (controller.transform.position + randomAdditiveVector);
        //if (Vector3.Distance(controller.transform.position, targetPosition) >= 0.25f)
        //{
        //    Vector3 direction = (targetPosition - controller.transform.position).normalized;
        //    controller.rb2DComponent.MovePosition(controller.transform.position + direction * patrolSpeed * Time.fixedDeltaTime);
        //    return;
        //}
        //else
        //{
        //    //randomize position once reached
        //    controller.rb2DComponent.velocity = new Vector2(0, 0);
        //    randomAdditiveVector = new Vector3(Random.Range(-distanceToPatrol, distanceToPatrol), Random.Range(-distanceToPatrol, distanceToPatrol));
        //}
        // if you're near target and cooldown is up go run
        // if you're near target and cooldown is up go run

        //controller.rb2DComponent.MovePosition(controller.transform.position + randomDirection * patrolSpeed * Time.fixedDeltaTime);
        //if (!hasStartedTimer)
        //{
        //    // start Timer
        //    hasStartedTimer = true;
        //    this.lastTimerTime = controller.timerManagerObj.CurTime;
        //}

        //if (!hasStartedTimer) return;
        //// if time's up
        //if ((controller.timerManagerObj.CurTime - this.lastTimerTime) >= timeToSwitch)
        //{
        //    Debug.Log("Patrolling");
        //    // end and reset timer
        //    hasStartedTimer = !hasStartedTimer;
        //    this.lastTimerTime = 0;
        //    randomDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
        //    randomDirection = (randomDirection - controller.transform.position).normalized;
        //    Debug.Log(randomDirection);
        //    //controller.rb2DComponent.velocity = new Vector2(0, 0);
        //}


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
