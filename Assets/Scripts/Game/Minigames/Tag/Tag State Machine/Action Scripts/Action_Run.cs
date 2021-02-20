using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Run : MonoBehaviour
{
    [SerializeField]private Transform targetToRunFrom;
    [SerializeField] private float distance;
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody2D rbComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunAwayFromTarget();
        TransitionToPatrol();
    }

    private void RunAwayFromTarget()
    {
        //Get the opposite direction of the target
        Vector3 TargetToRunTo = this.transform.position - targetToRunFrom.position;
        TargetToRunTo = TargetToRunTo.normalized;


        rbComponent.AddForce(TargetToRunTo * velocity * Time.fixedDeltaTime);
    }

    private void TransitionToPatrol()
    {
        Debug.Log(Vector3.Distance(this.transform.position, targetToRunFrom.position));
        //WIP
        if (Vector3.Distance(this.transform.position,targetToRunFrom.position) >= distance)
        {
            velocity = 0;
            rbComponent.velocity = new Vector2(0,0);
            return;
        }
        else
        {
            velocity = 15;
        }

    }
}
