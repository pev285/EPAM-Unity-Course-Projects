using UnityEngine;

public class HitOnTriggerEnter : MonoBehaviour {

    [SerializeField]
    private float healthDamage = -15f;

    public float HealthDamage {
        set {
            healthDamage = value;
        }
        get {
            return healthDamage;
        }
    }



    void OnTriggerEnter(Collider otherCollider) {

        Health h = otherCollider.gameObject.GetComponent<Health>();
        if (h != null) {
            h.ChangeHealthBy(HealthDamage);
        }

        // Visualize //
        AbstractProjectileHitVisualizer visualizer = GetComponent<AbstractProjectileHitVisualizer>();
        if (visualizer != null) {
            visualizer.HitPosition = transform.position;
            visualizer.Visualize();
        }

        Destroy(gameObject);
    }

}