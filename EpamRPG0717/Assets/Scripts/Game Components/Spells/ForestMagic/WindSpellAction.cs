using UnityEngine;

public class WindSpellAction : AbstractSpellAction {


    public override string Name {
        get {
            return "Wind Spell";
        }
    }

    public override string Description {
        get {
            return "Blows off nearest objects";
        }
    }

    [SerializeField]
    //private Vector3 relativeSpellCastPosition = new Vector3(0, 0, 1f);
    private float spellCastDistance = 1;
    [SerializeField]
    private float attackRadius = 4f;
    [SerializeField]
    private float powerAttackForce = 300f;


    private float upwardsModifier = 3.0F;

    public override void Cast(GameObject caster) {

        Vector3 explosionPos = caster.transform.position + caster.transform.forward * spellCastDistance;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, attackRadius);

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(powerAttackForce, explosionPos, attackRadius, upwardsModifier);
            }
        } // foreach collider //
    }


}
