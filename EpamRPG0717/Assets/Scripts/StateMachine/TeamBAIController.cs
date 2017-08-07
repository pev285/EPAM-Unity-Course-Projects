using UnityEngine;

public class TeamBAIController : AbstractAIController {

    TeamBAIStateMachine stateMachine;

    private ControllerEventSystem inputES;

    public override void SetControllerEventSystem(ControllerEventSystem ces)
    {
        inputES = ces;

        stateMachine = new TeamBAIStateMachine(gameObject, ces);
        //stateMachine.GoToState(StateMachine.State.Idle);


    }


    //////////////////////////////////////////////////

    void Start() {

    }

    void Update() {
        //stateMachine.ExecuteCurrentState();
    }

}