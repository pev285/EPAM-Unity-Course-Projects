using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {

    public enum State {
        Idle,
        Searching,
        Following,
        Firing,
        Escaping,
        Returning,

        InTransition,
    }

    public enum TransitionEvent {
        IdleToFollowing,
        FollowingToSearching,
        FollowingToEscaping,
        FollowingToFiring,
        SearchingToFollowing,
        SearchingToReturning,
        ReturningToFollowing,
        ReturningToIdle,
        EscapingToFollowing,
        FiringToFollowing,
        FiringToEscaping,
//        ReturningToEscaping,
    }


    //////////////////////////////////////////////


    private State currentState;
    public State CurrentState {
        get {
            return currentState;
        }
        set {
            currentState = value;
        }
    }

    public Dictionary<State, Action> nodes;
    public Dictionary<TransitionEvent, StateMachineTransition> transitions;

//    void Start() {
//
//    }



    public void GoToState(State state) {
        CurrentState = state;
//        nodes[state]();
        ExecuteCurrentState();
    }

    public void ExecuteCurrentState() {
        nodes[currentState]();
    }


    /////////////////////



    private void SimpleTransition(State current, State next)
    {
        if(current != next)
        {
            currentState = next;
//            ExecuteCurrentState();
        }
    }


    public void Trigger(TransitionEvent transitionEvent) {
        StateMachineTransition smt = transitions[transitionEvent];

        if (smt != null) {
            if (smt.IsCurrent(CurrentState)) {
                smt.Action(smt.FromState, smt.ToState);
            }
            else
            {
                Debug.LogError("Can't make transition for event " + transitionEvent
                    + " because current state is " + CurrentState);
            }
        }
        else
        {
            Debug.LogError("Cannot perform a transition. There is no transition for transitionEvent=" + transitionEvent);
        }
    }

}