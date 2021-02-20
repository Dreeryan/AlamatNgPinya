using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour
{

	//Updates the state
	public State RemainState;
	public State CurrentState;

	public LayerMask TargetLayerMask;
	public LayerMask GroundLayerMask;
   // [HideInInspector] public EnemyAI EnemyAIComponent;
	private bool aiActive;


	void Awake()
	{


		//EnemyAIComponent = GetComponent<EnemyAI>();
	}

	private void Start()
	{
		SetupAI();
	}

	public void SetupAI()
	{
	// Default variables on AI
		//if (aiActive)
		//{

		//	AIPath = GetComponent<AIPath>();
		//	AIDestinationSetter = GetComponent<AIDestinationSetter>();
		//	AIDestinationSetter.target = eyes;
		//}
		//else
		//{
	
		//}
	}
	private void Update()
	{
		if (!aiActive) return;
		CurrentState.UpdateState(this);
	}

	private void OnDrawGizmos()
	{
		//if (CurrentState != null && eyes !=null)
		//{
		//	Gizmos.color = CurrentState.SceneGizmoColor;
		//	Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
		//}
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
}