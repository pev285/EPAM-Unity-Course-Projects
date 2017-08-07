using UnityEngine;

public abstract class AbstractStateMachineStrategy : MonoBehaviour{

    protected GameObject target;
    protected CharacterModel chModel;
    protected TeamBAIStateMachine stateMachine;
    protected ControllerEventSystem eventSystem;


    public void Initialize(GameObject target, TeamBAIStateMachine stateMashine, ControllerEventSystem eventSystem) {

        print("Initialize is Working");

        this.target = target;
        if (target == null) {
            print("abstractstatemachinestrategy : target is null");
        }

        //this.chModel = target.GetComponent<CharacterModel>();
        this.stateMachine = stateMashine;
        this.eventSystem = eventSystem;
    }

    public GameObject GetTarget() {
        return target;
    }

}