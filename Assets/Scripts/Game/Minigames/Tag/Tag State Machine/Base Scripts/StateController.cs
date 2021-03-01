using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public Timer chaseActionTimer { get; private set; } = new Timer();
    public Timer patrolActionTimer { get; private set; } = new Timer();
    public Timer runActionTimer { get; private set; } = new Timer();
    public Timer runDecisionTimer { get; private set; } = new Timer();

    public Vector3 movementDirection = new Vector3();
    //components attached
    [SerializeField] public Rigidbody2D rb2DComponent;
	[SerializeField] public TagCharacter tagCharacterComponent;
	[SerializeField] public TagManager tagManagerObj;

	//nodes for ai patrolling and running away
	[SerializeField] public Transform currentTargetNode;
	[SerializeField] public Transform[] patrolNodes;
    [SerializeField] public Transform[] cornerNodes;
	//use this node list to determine far and nearby nodes
	public List<Transform> nodeCache = new List<Transform>();
	public TimerManager timerManagerObj { get; private set; }

	public Transform targetToRunFrom;
	//Updates the state
	public State RemainState;
	public State CurrentState;

	[SerializeField]private bool aiActive = true;
	public float gizmoSphereCastRadius;

    private void Start()
    {
		timerManagerObj = TimerManager.Instance;
    }
    private void Update()
	{
		if (!aiActive) return;
	//	if (GameManager.Instance.IsPaused) return;
		CurrentState.UpdateState(this);
	}

	private void OnDrawGizmos()
	{
        if (CurrentState != null )
        {
            Gizmos.color = CurrentState.SceneGizmoColor;
            Gizmos.DrawWireSphere(this.transform.position, gizmoSphereCastRadius);
        }
    }

	//Check if it's time to transition to the new state by 
	public void TransitionToState(State nextState)
	{
		//RemainState = CurrentState;
		// Could be null but makes remaining state more readable to the inspector
		// RemainState is a cache to the current state
		if (nextState != RemainState)
		{
			CurrentState = nextState;
		}
		
	}

    public void MoveToPosition(Vector3 direction,float speed)
    {
        this.rb2DComponent.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }


}