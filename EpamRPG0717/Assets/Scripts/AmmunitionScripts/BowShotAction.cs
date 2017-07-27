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
    [SerializeField]
    private float flightTime = 3.0f;

    private GameObject arrowPrefab;

    public BowShotAction(GameObject prefab) {
        this.arrowPrefab = prefab;
    }

    public override void Cast(UnityEngine.GameObject caster) {
        GameObject newArrow = GameObject.Instantiate(arrowPrefab, caster.transform.position + caster.transform.rotation * relativeSpellCastPosition,
                Quaternion.AngleAxis(90, caster.transform.right), caster.transform);


//        Rigidbody stoneRigidBody = newStone.GetComponent<Rigidbody>();
//        stoneRigidBody.velocity = (caster.transform.forward * bulletInitialVelocity);
//        stoneRigidBody.AddForce(caster.transform.forward * 300);

        Timer t = new Timer(newArrow, delegate  {
            GameObject.Destroy(newArrow);
        }, flightTime);
    }

}
