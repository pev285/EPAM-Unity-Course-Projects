using UnityEngine;

public class MagnetoSpellAction : AbstractSpellAction {

    public override string Name {
        get {
            return "Magneto Spell";
        }
    }

    public override string Description {
        get {
            return "Pulls near objects to the caster";
        }
    }

    [SerializeField]
    private Vector3 relativeSpellCastPosition = new Vector3(0, 0, 1f);
    [SerializeField]
    private float attackRadius = 4f;
    [SerializeField]
    private float powerAttackForce = 300f;


    private float upwardsModifier = 3.0F;

    public override void Cast(GameObject caster) {

        Vector3 explosionPos = caster.transform.position + relativeSpellCastPosition;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, attackRadius);

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce((caster.transform.position - rb.position).normalized * powerAttackForce);
            }
        } // foreach collider //
    }


}
