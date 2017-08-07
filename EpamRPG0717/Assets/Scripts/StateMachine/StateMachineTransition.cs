using System;

public class StateMachineTransition {

    private StateMachine.State fromState;
    private StateMachine.State toState;
    private Action<StateMachine.State, StateMachine.State> action;

    public StateMachineTransition(StateMachine.State from, StateMachine.State to, Action<StateMachine.State, StateMachine.State> action) {
        this.fromState = from;
        this.toState = to;
        this.action = action;
    }

    public bool IsCurrent(StateMachine.State state) {
        return fromState == state;
    }


    public StateMachine.State FromState {
        get {
            return fromState;
        }
    }

    public StateMachine.State ToState {
        get {
            return toState;
        }
    }

    public Action<StateMachine.State, StateMachine.State> Action {
        get {
            return this.action;
        }
    }

}

