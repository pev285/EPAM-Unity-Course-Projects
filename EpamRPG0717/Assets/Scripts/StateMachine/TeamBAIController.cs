using UnityEngine;

public class TeamBAIController : AbstractAIController {

    private TeamBAIStateMachine stateMachine;

    private ControllerEventSystem inputES;

    private Death death;


    public override void SetControllerEventSystem(ControllerEventSystem ces)
    {
        inputES = ces;

        stateMachine = new TeamBAIStateMachine(gameObject, ces);
        //stateMachine.GoToState(StateMachine.State.Idle);


    }


    //////////////////////////////////////////////////

    void Start() {
        death = GetComponent<Death>();
    }

    void Update() {
        //stateMachine.ExecuteCurrentState();

        if (death.IsDead)
        {
            stateMachine.Stop();
        }
    }

}