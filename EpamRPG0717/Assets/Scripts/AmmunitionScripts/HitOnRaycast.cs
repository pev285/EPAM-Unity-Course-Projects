using UnityEngine;

public class HitOnRaycast : MonoBehaviour {

    [SerializeField]
    private float healthDamage = -25f;

    public float HealthDamage {
        set {
            healthDamage = value;
        }
        get {
            return healthDamage;
        }
    }


    [SerializeField]
    private float maxDistance = 30f;


    void Start() {


        ///////////////////////////
        Vector3 raycastDirection = transform.forward;
        ///////////////////////////////
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, raycastDirection, out raycastHit, maxDistance)) {

            Collider otherCollider = raycastHit.collider;
            Health health = otherCollider.gameObject.GetComponent<Health>();
            if (health != null) {
                health.ChangeHealthBy(HealthDamage);
            }
//            Debug.Log("RaycastWorked: " + raycastHit.distance);


            // Visualize //
            AbstractProjectileHitVisualizer visualizer = GetComponent<AbstractProjectileHitVisualizer>();
            if (visualizer != null) {
                visualizer.HitPosition = raycastHit.point;
                visualizer.Visualize();
            }

        } // If Raycast //

    } // Start() //


}