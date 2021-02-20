using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;
    public Color SceneGizmoColor = Color.grey;
    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
        //Evaluate each of the actions and transitions       
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            // Loop over any transitions, each transitions will evaluate each decision and store it to the bool
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            // if it succeeds, then we'll transition to the true state
            // calls the StateController to change the state
            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                // can be remaining state or another state if it fails
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }

  
}
