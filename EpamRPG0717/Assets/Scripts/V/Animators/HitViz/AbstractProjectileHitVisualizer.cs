using UnityEngine;

public abstract class AbstractProjectileHitVisualizer : AbstractVisualizer {

    public abstract Vector3 HitPosition { set; get; }

    public abstract GameObject CrumbPrefab {set; get; }

}