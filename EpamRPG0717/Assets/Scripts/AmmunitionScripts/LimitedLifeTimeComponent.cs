using UnityEngine;

public class LimitedLifeTimeComponent : MonoBehaviour {

    [SerializeField]
    private float projectileLifeTime = 5f;


    [SerializeField]
    public float ProjectileLifeTime {
        set {
            projectileLifeTime = value;
        }
        get {
            return projectileLifeTime;
        }
    }

    void Start() {
        if (ProjectileLifeTime > 0) {
            new DestroyTimer(gameObject, ProjectileLifeTime);
        }
    }

}