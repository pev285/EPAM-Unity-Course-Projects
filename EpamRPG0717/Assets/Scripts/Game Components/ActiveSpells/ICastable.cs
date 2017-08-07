using UnityEngine;

public interface ICastable {

//    void Cast(GameObject caster, GameObject casterCamera, GameObject targetingPoint);
    void Cast(GameObject caster, Quaternion castRotation);

}
