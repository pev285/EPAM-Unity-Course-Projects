using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamBAIStateMachine : StateMachine {


    public Dictionary<State, string> nodeComponents;

    GameObject gameObject;
    ControllerEventSystem eventSystem;



    public TeamBAIStateMachine(GameObject go, ControllerEventSystem eventSystem) {

        this.gameObject = go;
        this.eventSystem = eventSystem;

        nodes = new Dictionary<State, Action>();
        transitions = new Dictionary<TransitionEvent, StateMachineTransition>();

        nodeComponents = new Dictionary<State, string>();


        nodes.Add(State.Idle, State_Idle);
        nodes.Add(State.Following, State_Following);
        nodes.Add(State.Searching, State_Searching);
        nodes.Add(State.Firing, State_Firing);
        nodes.Add(State.Escaping, State_Escaping);
        nodes.Add(State.Returning, State_Returning);
//        nodes.Add(State.Returning, State_Nothing);


        nodeComponents.Add(State.Idle, "IdleStrategy");
        nodeComponents.Add(State.Following, "FollowingStrategy");
        nodeComponents.Add(State.Searching, "SearchingStrategy");
        nodeComponents.Add(State.Firing, "FiringStrategy");
        nodeComponents.Add(State.Escaping, "EscapingStrategy");
        nodeComponents.Add(State.Returning, "ReturningStrategy");


        transitions.Add(TransitionEvent.IdleToFollowing,
                new StateMachineTransition(State.Idle, State.Following, TransitionFromIdleToFollowing));
        transitions.Add(TransitionEvent.FollowingToSearching,
                new StateMachineTransition(State.Following, State.Searching, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.FollowingToEscaping,
                new StateMachineTransition(State.Following, State.Escaping, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.FollowingToFiring,
                new StateMachineTransition(State.Following, State.Firing, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.SearchingToFollowing,
                new StateMachineTransition(State.Searching, State.Following, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.SearchingToReturning,
                new StateMachineTransition(State.Searching, State.Returning, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.ReturningToFollowing,
                new StateMachineTransition(State.Returning, State.Following, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.ReturningToIdle,
                new StateMachineTransition(State.Returning, State.Idle, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.EscapingToFollowing,
                new StateMachineTransition(State.Escaping, State.Following, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.FiringToFollowing,
                new StateMachineTransition(State.Firing, State.Following, ComponentAttachingTransition));
        transitions.Add(TransitionEvent.FiringToEscaping,
                new StateMachineTransition(State.Firing, State.Escaping, ComponentAttachingTransition));


        IdleStrategy strategy = gameObject.AddComponent<IdleStrategy>();
        strategy.Initialize(null, this, eventSystem);
        GoToState(State.Idle);

//  currentState = State.Idle;
    }


    //////////////////////////////////////////////////////////////////////////////




    private void TransitionFromIdleToFollowing(State current, State next) {

        IdleStrategy idleStrategy = gameObject.GetComponent<IdleStrategy>();
        GameObject target = idleStrategy.GetTarget();

        Debug.Log("Transition Idle to Following is working");
        if (target == null) {
            Debug.Log("transition: target is null");
        }

        ComponentAttachingTransition(current, next);

        FollowingStrategy followingStrategy = gameObject.GetComponent<FollowingStrategy>();

        followingStrategy.Initialize(target, this, eventSystem);
    }

    private void ComponentAttachingTransition(State current, State next) {

        if (current != next) {
            CurrentState = State.InTransition;

            Type previousType = Type.GetType(nodeComponents[current]);
            Type nextType = Type.GetType(nodeComponents[next]);

            Component previousStrategy = gameObject.GetComponent(previousType);

            if (previousStrategy != null) {
                GameObject.Destroy(previousStrategy);
                //previousStrategy.enabled = false;
            }


            Component nextStrategy = gameObject.GetComponent(nextType);
            if(nextStrategy == null) {
                nextStrategy = gameObject.AddComponent(nextType);
            }

            GoToState(next);
        }
    }


    private void SimpleTransition(State current, State next)
    {
        if(current != next)
        {
            CurrentState = next;
//            ExecuteCurrentState();
        }
    }


//////////////////////////////////////////////////////////

    private void State_Nothing() {
        // nothing //
    }

    private void State_Idle() {
        Debug.Log ("State: idle");
    }

    private void State_Following() {
        Debug.Log("State: following");
    }

    private void State_Searching() {
        Debug.Log("State: searching");
    }

    private void State_Firing() {
        Debug.Log("State: firing");
    }

    private void State_Escaping() {
        Debug.Log("State: escaping");
    }

    private void State_Returning() {
        Debug.Log("State: returning");
    }

    private void State_InTransition() {
        Debug.Log("State: in transition");
    }



} // End Of Class //


