using UnityEngine;

public class SearchingStrategy : AbstractStateMachineStrategy {

    [SerializeField]
    private float lookRadius = 20;

    //    [SerializeField]
    //    private GameObject enemy = null;

    void Update()
    {

        TeamID.Teams myTeam = gameObject.GetComponent<TeamID>().ThisTeam;
        float closestDistance = 2 * lookRadius * lookRadius;

        Collider[] colliders = Physics.OverlapSphere(transform.position, lookRadius);

        foreach (Collider col in colliders)
        {
            GameObject obj = col.gameObject;

            TeamID teamID = obj.GetComponent<TeamID>();

            if (teamID != null)
            {
                if (teamID.ThisTeam != myTeam && !obj.GetComponent<Death>().IsDead)
                {
                    float sqrDistance = (obj.transform.position - gameObject.transform.position).sqrMagnitude;
                    if (sqrDistance < closestDistance)
                    {
                        target = obj;
                        closestDistance = sqrDistance;
                    }
                }
            }

        } // foreach collider //

        if (target != null)
        {
            stateMachine.Trigger(StateMachine.TransitionEvent.SearchingToFollowing);
        }
    }

}