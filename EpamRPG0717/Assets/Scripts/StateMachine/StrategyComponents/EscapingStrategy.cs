using UnityEngine;

public class EscapingStrategy : AbstractStateMachineStrategy {


    private float almostOne = 0.99f;

    private float attackDistance = 100f;
    private float escapeDistance = 25f;

    private float rotationTime = 1f;

    void Update()
    {


        Vector3 toTargetVector = target.transform.position;
        toTargetVector = toTargetVector - gameObject.transform.position;

        float sqrDistance = toTargetVector.sqrMagnitude;

        if (sqrDistance >= attackDistance)
        {
            stateMachine.Trigger(StateMachine.TransitionEvent.EscapingToFollowing);
        }
        else
        {

            Vector3 targetDirection = toTargetVector.normalized;

            if (Vector3.Dot(targetDirection, transform.forward) > almostOne)
            {

                    eventSystem.InvokeStartBackEvent();

            }
            else
            {
                Quaternion lookRotation = Quaternion.LookRotation(toTargetVector);


                /*
                float angle = Quaternion.Angle(transform.rotation, lookRotation);


                print("Angle = " + angle);

                /*
                                gameObject.GetComponent<Rigidbody>().MoveRotation(
                                        Quaternion.Slerp(transform.rotation, lookRotation, rotationTime)
                                );
                                */
                //*
                float angle;
                Vector3 axis;

                Quaternion.FromToRotation(-transform.forward, toTargetVector.normalized).ToAngleAxis(out angle, out axis);

                //print("Angle = " + angle);

                if (angle > 180)
                {
                    angle -= 360;
                }

                //print("a=" + angle);

                float rotationAmount = 0; // angle > 0 ? 1 : -1;  
                if (angle > 0)
                {
                    rotationAmount = -1;
                }
                else if (angle < 0)
                {
                    rotationAmount = 1;
                }
                // */

                //float rotationAmount = 1;
                eventSystem.InvokeTurnHorizontalEvent(rotationAmount);


                //                    gameObject.GetComponent<Rigidbody>().MoveRotation(lookRotation);

            }

        }


    }

}