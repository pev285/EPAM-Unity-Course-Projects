using UnityEngine;

public class ForceApplicationMover : MonoBehaviour {

    [SerializeField]
    private float stoneThrowingForce = 400f;

    void Start() {

        Rigidbody stoneRigidBody = gameObject.GetComponent<Rigidbody>();
        if (stoneRigidBody != null) {
//        stoneRigidBody.velocity = (caster.transform.forward * bulletInitialVelocity);
            stoneRigidBody.AddForce(transform.forward * stoneThrowingForce);
        }

    }

}