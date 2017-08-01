using UnityEngine;

public class CrumbsVisualizer : AbstractProjectileHitVisualizer {

    [SerializeField]
    private float explosionForce = 100;
    [SerializeField]
    private float attackRadius = 3f;

    [SerializeField]
    private Vector3 hitPosition;

    [SerializeField]
    private float crumbLifeTime = 3.0f;



    [SerializeField]
    private const float delta = 0.1f;


    [SerializeField]
    private GameObject crumbPrefab;




    [SerializeField]
    public override GameObject CrumbPrefab {
        get {
            return crumbPrefab;
        }

        set {
            crumbPrefab = value;
        }
    }

    [SerializeField]
    public override Vector3 HitPosition {
        get {
            return hitPosition;
        }
        set {
            hitPosition = value;
        }
    }

// position of particles for small explosion //
    private Vector3[] positions = {
        new Vector3(0, 0, delta),
        new Vector3(0, 0, -delta),
        new Vector3(0, delta, 0),
        new Vector3(0, -delta, 0),
        new Vector3(delta, 0, 0),
        new Vector3(-delta, 0, 0)
    };

    public override void Visualize() {

        //HitPosition = transform.position;

        GameObject[] crumbs = new GameObject[6];

        for (int i = 0; i < 6; i++) {
            crumbs[i] = Instantiate(crumbPrefab, hitPosition + positions[i], Quaternion.identity);
            new DestroyTimer(crumbs[i], crumbLifeTime);
        }

        for (int i = 0; i < 6; i++) {

            Rigidbody rb = crumbs[i].GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, hitPosition, attackRadius);
            }
        }
    }





//
//    void OnDisable() {
//
////    }
////
////    void OnDestroy() {
//
//            HitPosition = transform.position;
//            Visualize();
//    }

}