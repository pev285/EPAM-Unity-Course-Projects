using UnityEngine;

public class ArrowMover : zzzAbstractProjectileLifeScript {


    private float lifeTime = 2f;


    public override float ProjectileLifeTime {
        set {
            lifeTime = value;
        }
        get {
            return lifeTime;
        }
    }

    ///////////////////////////////////////////////////

    [SerializeField]
    private float maxDistance = 30f;

    private Vector3 startingPoint;
    private Vector3 direction;
//    private Quaternion arrowDirection;





}