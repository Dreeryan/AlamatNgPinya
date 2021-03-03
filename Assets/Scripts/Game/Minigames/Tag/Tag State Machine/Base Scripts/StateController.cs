using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class StateController : MonoBehaviour
{
    public UnityEvent OnStateUpdate = new UnityEvent { };
    public LayerMask nodeLayerMask;
    public SpriteFlipper spriteRendererObj;
    public bool hasChosenTarget  { get; set; } = true;

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
        tagManagerObj.OnTagChanged.AddListener(UpdateTag);
    }
    private void Update()
	{
		if (!aiActive) return;
        //if (GameManager.Instance.IsPaused) return;
        SetDirection();
		CurrentState.UpdateState(this);
	}

    private void SetDirection()
    {
        spriteRendererObj.FlipSprite(movementDirection.x);
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
            OnStateUpdate.Invoke();
            hasChosenTarget = false;
        }
		
	}

    public void MoveToPosition(Vector3 direction,float speed)
    {
        this.rb2DComponent.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void UpdateTag()
    {
        targetToRunFrom = tagManagerObj.GetTaggedTransform();
    }

    public Transform GetRandomNearbyNode()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 3.5f, new Vector2(0, 0),0,nodeLayerMask);
        // List<Transform> nearbyNodes = new List<Transform>();
        if (hit == null) return null;
        if (hit.Length == 0) return null;

        if (hit.Length<=2)
        {
            return hit[0].transform;
        }
        else
        {
            return hit[Random.Range(0, hit.Length - 1)].transform;
        }
    }


    
}