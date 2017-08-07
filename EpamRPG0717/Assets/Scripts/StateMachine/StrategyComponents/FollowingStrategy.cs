using UnityEngine;

public class FollowingStrategy : AbstractStateMachineStrategy {

    private float almostOne = 0.9f;

    private float attackDistance = 25f;
    private float escapeDistance = 5f;

    private float rotationTime = 1f;

    void Update() {


        if (target == null) {
            print("followingstrategy: target is null");
        }

        Vector3 toTargetVector = target.transform.position - gameObject.transform.position;

        float sqrDistance = toTargetVector.sqrMagnitude;

        if (sqrDistance < escapeDistance) {
            stateMachine.Trigger(StateMachine.TransitionEvent.FollowingToEscaping);
        } else {

            Vector3 targetDirection = toTargetVector.normalized;

            if (Vector3.Dot(targetDirection, transform.forward) > almostOne) {
                if (sqrDistance <= attackDistance) {

                    eventSystem.InvokeFireEvent();
                } else {

                    eventSystem.InvokeStartForwardEvent();
                }

            } else {
                Quaternion lookRotation = Quaternion.LookRotation(toTargetVector);

                gameObject.GetComponent<Rigidbody>().MoveRotation(
                        Quaternion.Slerp(transform.rotation, lookRotation, rotationTime)
                );
            }

        }


    }
}

