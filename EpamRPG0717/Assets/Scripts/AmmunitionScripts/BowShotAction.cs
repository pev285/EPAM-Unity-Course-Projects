using UnityEngine;

public class BowShotAction : AbstractSpellAction{

    public override string Name {
        get {
            return "BowShot";
        }
    }

    public override string Description {
        get {
            return "Shot from a bow";
        }
    }

    [SerializeField]
    private Vector3 relativeSpellCastPosition = new Vector3(0, 1.5f, 1.0f);

    private GameObject arrowPrefab;

    public BowShotAction(GameObject prefab) {
        this.arrowPrefab = prefab;
    }

    public override void Cast(UnityEngine.GameObject caster) {
        Vector3 arrowPosition = caster.transform.position + caster.transform.rotation * relativeSpellCastPosition;
        Quaternion arrowRotation = caster.transform.rotation;   //Quaternion.AngleAxis(90, caster.transform.right);
        GameObject newArrow = GameObject.Instantiate(arrowPrefab, arrowPosition, arrowRotation);//, caster.transform);

    }

}
