using UnityEngine;

public class zzzStoneScript : zzzAbstractProjectileLifeScript {

    private float lifeTime = 5f;

    [SerializeField]
    public override float ProjectileLifeTime {
        set {
            lifeTime = value;
        }
        get {
            return lifeTime;
        }
    }



}