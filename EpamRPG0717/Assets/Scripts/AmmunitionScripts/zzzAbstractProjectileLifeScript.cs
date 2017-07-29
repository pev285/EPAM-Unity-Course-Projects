using UnityEngine;

public abstract class zzzAbstractProjectileLifeScript : MonoBehaviour {

    [SerializeField]
    private GameObject crumbPrefab;
    //[SerializeField]
    private AbstractProjectileHitVisualizer visualizer;

    [SerializeField]
    public abstract float ProjectileLifeTime { set; get; }




    void Start() {

        visualizer = GetComponent<AbstractProjectileHitVisualizer>();
        if (visualizer != null) {
            visualizer.CrumbPrefab = (crumbPrefab);
        }


        if (ProjectileLifeTime > 0) {
            new DestroyTimer(gameObject, ProjectileLifeTime);
        }
    }




    void OnDestroy() {
        if (visualizer != null) {
            visualizer.HitPosition = (transform.position);
            visualizer.Visualize();
        }
    }

}